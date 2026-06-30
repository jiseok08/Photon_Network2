using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void SetMouse(bool state)
    {
        Cursor.visible = state;

        Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneOnad)
    {
        switch(scene.buildIndex)
        {
            case 2:
                SetMouse(false); 
                break;
            default:
                SetMouse(true);
                break;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
