using UnityEngine;
using System.Collections;

public class Window
{
    #region Window Properties

    public string name;

    #endregion

    #region Components

    public enum WindowComponents {SpriteRenderer, Animator}

    public enum WindowType {PauseWindow}

    #endregion

    public Window(GameObject gameObj, WindowComponents windowComponent)
    {
        name = gameObj.name;

        AddComponentOf(gameObj,windowComponent.ToString());
    }

    public void AddComponentOf(GameObject gameObj, string name)
    {
        gameObj.AddComponent(name);
    }

    public static string GetWindowTypeName(WindowType windowType)
    {
        string windowTypeName;

        switch(windowType)
        {
            case WindowType.PauseWindow:
               windowTypeName = "PauseWindow";
               break;

            default:
               Debug.Log("Error Renaming Window.");
               windowTypeName = "";
               break;
        }

        return windowTypeName;
    }

    public static void CenterWindow(GameObject gameObj)
    {
        gameObj.transform.position = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);
    }

    public static GameObject CreateWindowOfType(WindowType windowType)
    {
        GameObject windowGameObj;

        switch (windowType)
        {
            case WindowType.PauseWindow:
                windowGameObj = Resources.Load<GameObject>("PauseMenu");
                break;

            default:
                windowGameObj = null;
                Debug.Log("Error loading window resources.");
                break;
        }

        return windowGameObj;
    }

    public static void DestroyWindow(GameObject gameObj)
    {
        GameObject.Destroy(gameObj);
    }
}
