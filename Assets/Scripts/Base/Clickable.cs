using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour
{
    #region Click Components

    Ray ray;

    RaycastHit2D rayCast;

    #endregion

    void Awake()
    {
        this.gameObject.AddComponent("BoxCollider2D");
    }

    public bool OnHover()
    {
        bool hovered = false;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //trace a ray from camera to point on screen in world coordinates
        rayCast = Physics2D.Raycast(ray.origin, Vector2.zero);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (rayCast.collider != null)
        {
            if (rayCast.collider.gameObject.name == this.gameObject.name)
                hovered = true;
            else
                hovered = false;
        }

        return hovered;
    }

    public bool OnClicked()
    {
        bool clicked = false;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //trace a ray from camera to point on screen in world coordinates
        rayCast = Physics2D.Raycast(ray.origin, Vector2.zero);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Input.GetMouseButtonDown(0))
        {
            if (rayCast.collider != null)
            {
                if (rayCast.collider.gameObject.name == this.gameObject.name)
                    clicked = true;
                else
                    clicked = false;
            }
        }

        return clicked;
    }
}
