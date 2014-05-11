using UnityEngine;
using System.Collections;

public class ButtonEvent : Clickable
{
    #region GUI Sprite Hover

    public Sprite onHovered;

    public Sprite notHovered;

    public bool useSprite = false;

    #endregion

    #region Name Scene To Load

    public string sceneName;

    #endregion

    #region Action Flags

    public bool sceneToLoad = false;

    public bool quitGame = false;

    public bool unPauseGame = false;

    public bool pauseGame = false;

    #endregion

    // Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (OnHover())
           GetComponent<SpriteRenderer>().sprite = onHovered;
        else
           GetComponent<SpriteRenderer>().sprite = notHovered;

        if (OnClicked() && unPauseGame)
            GameApp.PauseGame();
        if (OnClicked() && sceneToLoad)
            GameApp.Load(sceneName);
        if (OnClicked() && quitGame)
            GameApp.Quit();
	}
}
