using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

public class ItemDataEditor : OdinMenuEditorWindow
{
    [MenuItem("Tools/ItemEditor")]
    static void OpenWindow()
    {
        GetWindow<ItemDataEditor>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        throw new System.NotImplementedException();
    }
}
