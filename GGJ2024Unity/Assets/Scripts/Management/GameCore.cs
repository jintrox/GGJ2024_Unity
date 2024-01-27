using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class GameCore : AllosiusDevUtilities.Singleton<GameCore>
{
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
#if UNITY_EDITOR
        
        if (Input.GetKeyDown(SFPSC_KeyManager.QuitPlayMode))
        {
            Debug.Log("Quit Play Mode");
            EditorApplication.ExitPlaymode();
        }
#endif
    }
}
