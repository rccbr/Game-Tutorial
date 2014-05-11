using UnityEngine;
using System.Collections;

public static class GameApp
{
    #region Game Screen

    public enum GameScreen {MainMenu, Intro, Instructions, Options, GamePlay, Pause, Store, Credits}

    private static string screenName;

    #endregion

    #region Camera Colors FadeIn

    public static Color colorInitial;

    public static Color colorEnd;

    public static float duration = 3.0f;

    public static bool finished = false;

    #endregion

    #region Game Pause

    public static bool pauseGame = false;

    #endregion


    static void CheckScreen(GameScreen screen)
    {
        switch(screen)
        {
            case GameScreen.MainMenu:
                screenName = GameScreen.MainMenu.ToString();
                break;

            case GameScreen.GamePlay:
                screenName = GameScreen.GamePlay.ToString();
                break;
        }
    }

    public static void PauseGame()
    {
        pauseGame = !pauseGame;

        if (pauseGame)
        {
            GameObject pauseWindow = Object.Instantiate(Window.CreateWindowOfType(Window.WindowType.PauseWindow),
                Camera.main.transform.GetComponent<CameraFollow>().windowMenuPos.position, Quaternion.identity) as GameObject;

            pauseWindow.name = "PauseWindow";

            GameObject.Find("GUIManager").gameObject.GetComponent<GUIManager>().AssignNewWindow();
        }
            
        else
        {
            Time.timeScale = 1.0f;

            //Window.DestroyWindow(GameObject.Find(Window.GetWindowTypeName(Window.WindowType.PauseWindow)));
        }
            
    }

    public static void Load(string screenName)
    {
        Application.LoadLevel(screenName);
    }

    public static void Quit()
    {
        Application.Quit();
    }

    
}
