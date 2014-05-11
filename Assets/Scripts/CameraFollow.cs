using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	#region Camera Speed

	public float cameraSpeed = 2.0f;

	#endregion

	#region Player Instance

	public Movimento player;

	#endregion

	#region Move Camera To Start

	public bool moveToStart = false;

	public Transform startCamera;

	#endregion

    #region Window Pause Position

    public Transform windowMenuPos;

    #endregion

    // Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        //windowMenuPos.position = transform.position;

		if (player && !moveToStart)
		{
			if (player.transform.position.x > transform.position.x - 5.75f && player.facingRight && !player.died)
				transform.Translate(cameraSpeed*Time.deltaTime,0.0f,0.0f);

			if (player.transform.position.x < transform.position.x + 5.75f && !player.facingRight && !player.died)
				transform.Translate(-cameraSpeed*Time.deltaTime,0.0f,0.0f);
		}

		if (moveToStart)
		{
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, startCamera.position.x,1.0f*Time.deltaTime), transform.position.y, transform.position.z);
		}
	}
}
