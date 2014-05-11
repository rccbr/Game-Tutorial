using UnityEngine;

public class CharacterBaseMovement : Movement {

	float speed = 0.0f;
	bool right = false;
	bool left = false;

	public float speedMovement
	{
		get { return speed; }
		set {speed = value; }
	}

	public bool goingRight 
	{
		get { return right; }
		set { right = value; }
	}

	public bool goingLeft 
	{
		get { return left; }
		set { left = value; }
	}

	public void move(GameObject go, float horizontalForce, bool NPC)
	{
		if (!NPC)
		{
			if (horizontalForce > 0.1f)
			{
				go.transform.Translate(speed*Time.deltaTime * 1.0f,0.0f,0.0f);
				go.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
			}
			
			if (horizontalForce < -0.1f)
			{
				go.transform.Translate(speed*Time.deltaTime * -1.0f,0.0f,0.0f);
				go.transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
			}
		}

		if (NPC)
		{
			if (goingRight)
			{
				go.transform.Translate(speed*Time.deltaTime * 1.0f,0.0f,0.0f);
				go.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
			}

			if (goingLeft)
			{
				go.transform.Translate(speed*Time.deltaTime * -1.0f,0.0f,0.0f);
				go.transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
			}
		}
	}
}
