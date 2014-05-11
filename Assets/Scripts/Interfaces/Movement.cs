using UnityEngine;

interface Movement 
{
	float speedMovement
	{
		get;
		set;
	}

	bool goingRight 
	{
		get;
		set;
	}

	bool goingLeft
	{
		get;
		set;
	}

	void move(GameObject go, float horizontalForce, bool NPC);
}
