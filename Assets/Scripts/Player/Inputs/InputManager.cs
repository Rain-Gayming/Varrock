using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static PlayerInputs inputActions;
    public static InputManager instance;
    public bool reciveInputs = true;

    public static event Action rebindComplete;
    public static event Action rebindCanceled;
    public static event Action<InputAction, int> rebindStarted;

    static KeybindData myKeybindData = new KeybindData();
    public static string saveFile;

    [Header("Movement")]
    public Vector2 walking;
    public bool jumping;
    public bool aiming;
    public bool sprinting;
    public bool crouching;
    public Vector2 looking;

    [Header("Mouse")]
    public bool leftMouse;
    public bool rightMouse;
    public Vector2 scrollWheel;
    
    [Header("UI")]
    public bool inventory;
    public bool magicCrafting;
    public bool pause;
    public bool fpsToggle;

    [Header("Gameplay")]
    public bool interact;
    public bool altInteract;

    private void Awake() {
        instance = this;
        inputActions = new PlayerInputs();
        inputActions.Enable();
        saveFile = Application.persistentDataPath + "/keybindings.json";
    }    

    private void Update() {
        if(reciveInputs){
            walking = inputActions.Movement.Walking.ReadValue<Vector2>();

            inputActions.Movement.Jumping.performed += x => jumping = true;
            inputActions.Movement.Jumping.canceled += x => jumping = false;

            inputActions.Movement.Crouching.performed += x => crouching = true;
            inputActions.Movement.Crouching.canceled += x => crouching = false;

            inputActions.Movement.Sprinting.performed += x => sprinting = true;
            inputActions.Movement.Sprinting.canceled += x => sprinting = false;

            looking = inputActions.Movement.Looking.ReadValue<Vector2>();
            Mathf.Clamp(looking.x, 0, 1);
            Mathf.Clamp(looking.y, 0, 1);

            inputActions.Mouse.LeftMouse.performed += x => leftMouse = true;
            inputActions.Mouse.LeftMouse.canceled += x => leftMouse = false;
            inputActions.Mouse.RightMouse.performed += x => rightMouse = true;
            inputActions.Mouse.RightMouse.canceled += x => rightMouse = false;
            scrollWheel = inputActions.Mouse.Scroll.ReadValue<Vector2>();
            scrollWheel.y = Mathf.Clamp(scrollWheel.y, -1, 1);
            
            inputActions.UI.Inventory.performed += x => inventory = true;
            inputActions.UI.Inventory.canceled += x => inventory = false; 
            inputActions.UI.MagicCrafting.performed += x => magicCrafting = true;
            inputActions.UI.MagicCrafting.canceled += x => magicCrafting = false;             
            inputActions.UI.Pause.performed += x => pause = true;
            inputActions.UI.Pause.canceled += x => pause = false;
            inputActions.UI.FPSToggle.performed += x => fpsToggle = true;
            inputActions.UI.FPSToggle.canceled += x => fpsToggle = false;
            
            inputActions.Gameplay.Interact.performed += x => interact = true;
            inputActions.Gameplay.Interact.canceled += x => interact = false; 
            inputActions.Gameplay.AltInteract.performed += x => altInteract = true;
            inputActions.Gameplay.AltInteract.canceled += x => altInteract = false; 
        }else{
            inventory = false;
        }
    }


    public static void StartRebind(string actionName, int bindingIndex, TMP_Text statusText)
    {
        InputAction action = inputActions.asset.FindAction(actionName);

        if(action == null || action.bindings.Count <= bindingIndex){
            Debug.Log("Couldn't find action or binding");
            return;
        }
        
        if(action.bindings[bindingIndex].isComposite){
            var firstPartIndex = bindingIndex + 1;
            if(firstPartIndex < action.bindings.Count && action.bindings[firstPartIndex].isComposite){
                DoRebind(action, bindingIndex,statusText,true);
            }

        }else{
            DoRebind(action, bindingIndex, statusText, false);
        }
    }

    public static void DoRebind(InputAction actionToRebind, int bindingIndex, TMP_Text statusText, bool allCompositeParts)
    {
        if(actionToRebind == null || bindingIndex < 0){
            return;
        }

        statusText.text = $"Press a {actionToRebind.expectedControlType}";

        actionToRebind.Disable();

        var rebind = actionToRebind.PerformInteractiveRebinding(bindingIndex);

        rebind.OnComplete(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();

            if(allCompositeParts){
                var nextBindingIndex = bindingIndex + 1;
                if(nextBindingIndex < actionToRebind.bindings.Count && actionToRebind.bindings[nextBindingIndex].isComposite){
                    DoRebind(actionToRebind, nextBindingIndex, statusText, allCompositeParts);
                }
            }

            rebindComplete?.Invoke();

            SaveBindingOverride(actionToRebind);
        });
        rebind.OnCancel(operation =>
        {
            actionToRebind.Enable();
            operation.Dispose();
            rebindCanceled?.Invoke();
        });

        rebindStarted?.Invoke(actionToRebind, bindingIndex);
        rebind.Start();
    }

    public static string GetBindingName(string actionName, int bindingIndex)
    {
        if(inputActions == null){
            inputActions = new PlayerInputs();
            inputActions.Enable();
        }

        InputAction action = inputActions.asset.FindAction(actionName);

        return action.GetBindingDisplayString(bindingIndex);
    }

    public static void ResetBinding(string actionName, int bindingIndex)
    {
        InputAction action = inputActions.asset.FindAction(actionName);

        if(action == null || action.bindings.Count <= bindingIndex){
            Debug.Log("Coudnt find action or binding");
            return;
        }

        if(action.bindings[bindingIndex].isComposite){
            for (int i = bindingIndex; i < action.bindings.Count && action.bindings[i].isComposite; i++)
            {
                action.RemoveBindingOverride(i);
            }
        }else
        {
            action.RemoveBindingOverride(bindingIndex);
        }
    }

    public static void SaveBindingOverride(InputAction action)
    {
        for (int i = 0; i < action.bindings.Count; i++)
        {
            //replace with something like json saving
            PlayerPrefs.SetString(action.actionMap + action.name + i, action.bindings[i].overridePath);

            string jsonString = JsonUtility.ToJson(myKeybindData);
            inputActions.SaveBindingOverridesAsJson();
            myKeybindData.inputAction = inputActions;
            
            File.WriteAllText(saveFile, jsonString);
            
        }
    }

    public static void LoadBindingOverride(string actionName)
    {
        if(inputActions == null){
            inputActions = new PlayerInputs();

        }

        //inputActions.LoadBindingOverridesFromJson(saveFile);

        InputAction action = inputActions.asset.FindAction(actionName);

        for (int i = 0; i < action.bindings.Count; i++)
        {
            if(!string.IsNullOrEmpty(PlayerPrefs.GetString(action.actionMap + action.name + i)))
                action.ApplyBindingOverride(i, PlayerPrefs.GetString(action.actionMap + action.name + i));
        }
    }
}
[System.Serializable]
public class KeybindData
{
    public PlayerInputs inputAction;
}
