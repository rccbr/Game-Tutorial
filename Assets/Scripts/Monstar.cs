using UnityEngine;
using System.Collections;

public class Monstar : MonoBehaviour, PowerDamage {

	#region Movement Variables

	public float speed = 2.0f;

	#endregion

	#region Movement Boolean

	public bool isGrounded = false;

	public bool isPlataformEnd = false;

	#endregion

	#region Ground

	public Transform ground;

	#endregion

	#region Plataform

	public GameObject currentPlataform;

	#endregion

	#region Direction

	public bool flip = true;

	public bool turn = true;

	public bool enableJumpTrigger = true;

	public bool enableTurnTriggerLeft = true;

	public bool enableTurnTriggerRight = false;

	public bool goingLeft = false;

	public bool goingRight = false;

	#endregion

	#region Jump

	public bool jumping = false;

	public bool canJump = true;

	#endregion

	#region Animator 

	private Animator anim;

	private AnimatorStateInfo currentBaseState;

	#endregion

	#region Animation States

	static int walkState = Animator.StringToHash("Base Layer.walk");
	//static int awakeState = Animator.StringToHash("Base Layer.awake");
	//static int jumpState = Animator.StringToHash("Base Layer.Jump");

	#endregion

	#region Power Damage 

	public float power = 0.01f;

	#endregion

	//Implementing the property
	public float powerDamage
	{
		get
		{
			return power;
		}

		set
		{
			power = value;
		}

	}

	//Implementing the Power Damage method
	public void DamagePlayerBy(float pwr, Collision2D col)
	{
		col.gameObject.transform.FindChild("Health").FindChild("lifeBar").GetComponent<Energy>().GotDamage(pwr);
	}

	// Use this for initialization
	void Awake () 
	{
		//getting animator component
		anim = GetComponent<Animator>();

		//assign the ground game object
		ground = transform.FindChild("ground");

		//getting the animation state base
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//check if the monster is on the ground
		isGrounded = Physics2D.Linecast(transform.position, ground.position, 1 << LayerMask.NameToLayer("ground")); 


		//**************************************************************************************
		//*********************Moving the Monstar based on Direction**************************
		//**************************************************************************************

		if (goingLeft)
		{
			Flip(-1.0f);
			transform.Translate(speed*-1.0f*Time.deltaTime,0.0f,0.0f);
		} 

		if (goingRight)
		{
			Flip(1.0f);
			transform.Translate(speed*Time.deltaTime,0.0f,0.0f);
		}


		//*******************************************************************************************************
		//************************************Monstar Walk State************************************************
		//*******************************************************************************************************


		if (currentBaseState.nameHash == walkState)
		{
			canJump = true;
		}

		if (isGrounded)
		{
			jumping = false;
			anim.SetBool("jump", jumping);
		}

		if (!isGrounded)
		{
			jumping = true;
			anim.SetBool("jump", jumping);
		}
	}

	void Flip(float direction)
	{
		//flip the Texture
		transform.localScale = new Vector3(direction,1.0f,1.0f);
	}

	void Jump()
	{
		anim.SetBool("jump", jumping);

		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

		if (canJump)
		{
			Debug.Log("Jump");

			rigidbody2D.AddForce (new Vector2 (-100.0f, 500.0f));

			canJump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			DamagePlayerBy(power, col);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "endLeft" && !turn && enableJumpTrigger)
		{
			jumping = true;
			Jump ();
			enableJumpTrigger = false;
		}

		if (goingLeft && coll.gameObject.name == "endRight" && !enableJumpTrigger)
		{
			enableJumpTrigger =true;
		}

		if (coll.gameObject.name == "endLeft" && turn && enableTurnTriggerLeft)
		{
			goingLeft = false;
			goingRight = true;
			enableTurnTriggerLeft = false;
			enableTurnTriggerRight = true;
		}

		if (coll.gameObject.name == "endRight" && turn && enableTurnTriggerRight)
		{
			goingRight = false;
			goingLeft = true;
			enableTurnTriggerRight = false;
			enableTurnTriggerLeft = true;
		}
	}
}
