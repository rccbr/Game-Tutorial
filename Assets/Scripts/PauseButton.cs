using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour 
{
    #region Rectangle

    Rect rect;

    #endregion

    #region Texture Position

    public Texture2D pauseBt;

    public Texture2D pauseBtHovered;

    public float texPositionX;

    public float texPositionY;

    public float offsetX;

    public float offsetY;

    #endregion

    #region Hovered Boolean

    public bool hovered = false;

    public bool clicked = false;

    #endregion

    void Awake()
    {
        texPositionX = Screen.width / 2 - offsetX;
        texPositionY = Screen.height / 2 - offsetY;

        rect = new Rect(texPositionX, texPositionY, 64.0f, 64.0f);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (clicked)
            GUI.DrawTexture(rect, pauseBtHovered);
        else
            GUI.DrawTexture(rect, pauseBt);

        Event e = Event.current;

        if (e.type == EventType.MouseDown)
        {
            if (rect.Contains(e.mousePosition))
            {
                clicked = true;
                GameApp.PauseGame();
            }
        }

        if (e.type == EventType.MouseUp)
        {
            if (rect.Contains(e.mousePosition))
            {
                clicked = false;
            }
        }
    }
}
