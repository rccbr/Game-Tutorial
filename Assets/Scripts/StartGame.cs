using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	#region Texture Position and Size

	public float offsetX;
	public float offsetY;

	private float texPositionX;
	private float texPositionY;
	
	public float texWidth;
	public float texHeight;

	#endregion

	public GUIStyle customStyle;

	public Texture2D button;

	public string level;

	// Use this for initialization
	void Start () 
	{
		texPositionX = Screen.width/2-offsetX;
		texPositionY = Screen.height/2-offsetY;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{

		Rect rec = new Rect(texPositionX, texPositionY,texWidth,texHeight);
		GUI.DrawTexture(rec, button);

		Event e = Event.current;

		if (e.type == EventType.MouseDown) {
			if (rec.Contains(e.mousePosition))
			{
				if (audio && !audio.isPlaying)
					audio.Play();

				if (level != "")
			    	Application.LoadLevel(level);
				else
					Application.Quit();

			}
		}
	}
}
