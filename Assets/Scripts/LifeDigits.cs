using UnityEngine;
using System.Collections;

public class LifeDigits : MonoBehaviour {

	public int lifeCount = 3;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.FindChild("digitOne").GetComponent<GUITexture>().texture = GetComponent<OneDigit>().getDigit(lifeCount);
	}
}
