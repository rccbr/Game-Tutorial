using UnityEngine;
using System.Collections;

public class Limite : MonoBehaviour {

	public bool heroDied = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			heroDied = true;
		}
	}
}
