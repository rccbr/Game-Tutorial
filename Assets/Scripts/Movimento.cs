using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (Rigidbody2D))]

public class Movimento : Stoppable {

	#region Animation

	private Animator anim;

	private AnimatorStateInfo currentBaseState;

	#endregion

	#region Animation States

	static int idleState = Animator.StringToHash("Base Layer.idle");
	static int runState = Animator.StringToHash("Base Layer.Run");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");

	#endregion

	#region Movement Variables

	public float speed = 2.0f;

	public bool moving = false;

	public bool jumping = false;

	public bool canJump = false;

	private float horizontal;

	public bool stopInput = false;

	#endregion

	#region Character Base Movement

	CharacterBaseMovement locomotion;

	#endregion

	#region Check Stamina Counting

	public bool enableCounting = false;

	public bool fullGas = false;

	#endregion

	#region Flip Texture Variables

	public bool flip = false;

	public bool facingRight = true;

	#endregion

	#region Check Ground variables

	public Transform ground;
	
	public bool isGrounded = false;

	#endregion

	#region Life

	public Energy lifeBar;

	public int life =3;

	#endregion

	#region Health variables

	public bool checkDied = true;

	public bool died = false;

	#endregion

	#region Collect Items

	public bool gotCoin = false;

	#endregion


	void Awake()
	{
		//getting the spawn position
		//spawn = transform.FindChild("Spawn").transform;

		locomotion = new CharacterBaseMovement();

		//adjusting spawn position according to camera position
		//spawn.position = new Vector3(Camera.main.transform.position.x/2-4.0f,Camera.main.transform.position.y/2,spawn.position.z);
	}

	// Use this for initialization
	void Start () 
	{
		//getting the animator component
		anim = GetComponent<Animator>();

		//finding the life bar
		lifeBar = transform.FindChild("Health").FindChild("lifeBar").GetComponent<Energy>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//check if the player is on the ground
		isGrounded = Physics2D.Linecast(transform.position, ground.position, 1 << LayerMask.NameToLayer("ground")); 

		//getting the animation state base
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		//input controls
		if (!stop)
			Move();

		//Check if the player gets tired
		if (fullGas)
			CheckPlayerStamina();

		if (checkDied)
			CheckHealth();
	}

	void Move()
	{
		//***************************************************************
		//******************Control animator parameters******************
		//***************************************************************

		horizontal = Input.GetAxis("Horizontal");

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		//******************************************************************************
		//******************Hero is moving to the right or to the left******************
		//******************************************************************************

		if (horizontal > 0.1f && isGrounded)
		{
			anim.SetBool("run", true);
			moving = true;
			facingRight = true;
			Flip (1.0f);
		} 

		if (horizontal < 0.0f && isGrounded)
		{
			anim.SetBool("run", true);
			moving = true;
			facingRight = false;
			Flip (-1.0f);
		}

		if (currentBaseState.nameHash != idleState)
		{
			enableCounting = true;
			
			fullGas = true;

			anim.SetBool("die", false);
		}

		if (currentBaseState.nameHash == runState || currentBaseState.nameHash == jumpState)
		{
			anim.SetBool("tired", false);

			//CancelInvoke();

			StopCoroutine("idleCountingUntilGetTired");

			Debug.Log("Stop Coroutine.");
		}


		//*********************************************************
		//******************Hero is moving or not******************
		//*********************************************************

		if (horizontal == 0.0f)
		{
			moving = false;
			anim.SetBool("run", false);
		}



		//**************************************************************************************
		//******************Translate the hero based on the direction he is facing**************
		//**************************************************************************************

		if (moving && facingRight)
		{
			locomotion.speedMovement = speed;
			locomotion.move(this.gameObject, horizontal, false);
		}
		
		if (moving && !facingRight)
		{
			locomotion.speedMovement = speed;
			locomotion.move(this.gameObject, horizontal, false);
		}



		//****************************************
		//******************Jump******************
		//****************************************

		if (canJump)
		{
			if (Input.GetButtonDown ("Jump") )
			{
				jumping = true;
				Jump();
                canJump = false;
			}
		}

		if (!isGrounded && !died)
		{
			canJump = false;
			jumping = true;
			anim.SetBool("jump", jumping);
		}

		if (isGrounded && !died)
		{
			canJump = true;
			jumping = false;
			anim.SetBool("jump", jumping);
		}
	}

	void Jump()
	{
        Debug.Log("JUMP.");

		anim.SetBool ("jump", jumping);
		
		if (!moving && canJump)
		{
			rigidbody2D.AddForce (new Vector2 (0.0f, 500.0f));
		}
		
		if (facingRight && horizontal > 0.0f && canJump)
		{
			rigidbody2D.AddForce (new Vector2 (100.0f, 500.0f));
		}
		
		if (!facingRight && horizontal < 0.0f && canJump)
		{
			rigidbody2D.AddForce (new Vector2 (-100.0f, 500.0f));
		}
	}

	void Flip(float direction)
	{
		Vector3 flipVector = new Vector3(1.0f*direction,1.0f,1.0f);
		transform.localScale = flipVector;
	}

	void CheckPlayerStamina()
	{
		if (currentBaseState.nameHash == idleState)
		{
			if (enableCounting)
			{
				//Invoke("idleCountingUntilGetTired", 10.0f);

				StartCoroutine("idleCountingUntilGetTired");
				
				enableCounting = false;

				fullGas = false;
			}
		}
	}

	void CheckHealth()
	{
		if (lifeBar.energy <= .0f)
		{
			stopInput = true;
			GetComponent<CircleCollider2D>().center = new Vector2(GetComponent<CircleCollider2D>().center.x, 0.01f);
			anim.SetBool("die", true);
			anim.SetBool("jump",false);
			anim.SetBool("run",false);
			Destroy(GetComponent<BoxCollider2D>());
			Destroy(GetComponent<CircleCollider2D>());
			StartCoroutine("waitUntilPlayerFalls");
			checkDied = false;
		}
	}

	public void RecoverComponents()
	{
		if (!GetComponent<BoxCollider2D>())
		{
			this.gameObject.AddComponent("BoxCollider2D");
			GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 0.76f);
			GetComponent<BoxCollider2D>().center = new Vector2(0.0f, 0.12f);
		}

		if (!GetComponent<CircleCollider2D>())
		{
			this.gameObject.AddComponent("CircleCollider2D");
			GetComponent<CircleCollider2D>().radius = 0.3f;
			GetComponent<CircleCollider2D>().center = new Vector2(0.0f,-0.2f);
		}
	}

	IEnumerator idleCountingUntilGetTired()
	{
		Debug.Log("idleCountingUntilGetTired");

		yield return new WaitForSeconds(10.0f);

		anim.SetBool("tired", true);
	}

    IEnumerator waitUntilPlayerFalls()
    {
	    Debug.Log("waitUntilPlayerFalls");

	    yield return new WaitForSeconds(3.0f);

	    died = true;
    }

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Coin")
		{
			gotCoin = true;
		}
	}

	public void printName(GameObject thisGameobj)
	{
		Debug.Log("Object Name: " + thisGameobj.name);
	}
}
