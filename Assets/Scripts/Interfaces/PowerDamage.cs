using UnityEngine;

//Design Pattern Strategy
interface PowerDamage
{
	float powerDamage 
	{
		get;
		set;
	}

	void DamagePlayerBy(float pwr, Collision2D col);
}

