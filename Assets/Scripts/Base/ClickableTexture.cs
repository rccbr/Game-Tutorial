using UnityEngine;
using System.Collections;

public class ClickableTexture : MonoBehaviour 
{
    #region Rectangle

    Rect rect;

    #endregion

    #region Texture Position

    protected float texPositionX;

    protected float texPositionY;

    #endregion
	
	void Awake () 
    {
	    rect = new Rect(texPositionX, texPositionY,64.0f,64.0f);
		
	}
	
	public bool OnHover()
    {
        bool hovered = false;

		Event e = Event.current;

        if (e.type == EventType.MouseDown)
        {
            if (rect.Contains(e.mousePosition))
            {

            }
        }

        return hovered;
    }

    public bool OnClicked()
    {
        bool clicked = false;

        return clicked;
    }
}
