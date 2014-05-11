using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		transform.position = new Vector3(transform.parent.position.x/2-7.0f,transform.position.y/2+2.0f, transform.position.z);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
