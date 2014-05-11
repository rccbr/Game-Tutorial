using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public float timeToRestart = 0.0f;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("RestartGame");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(timeToRestart);

		Application.LoadLevel("MainMenu");
	}
}
