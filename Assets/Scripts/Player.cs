using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private CharacterBaseMovement movement;

	public float speedLocomotion = 2.0f;

	private Animator anim;

	public Transform groundPos;

	void Awake()
	{
		movement = new CharacterBaseMovement();
	}
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

		groundPos = transform.FindChild("ground").transform;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal"); 

		if (h != 0.0f)
		{
			anim.SetBool("run", true);
			movement.speedMovement = speedLocomotion;
			movement.move(gameObject, h, false);
		}

		if (h == 0.0f)
			anim.SetBool("run", false);
	}
}
