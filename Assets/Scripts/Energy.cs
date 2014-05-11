using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

	private Vector3 positioning;

	public float energy = 1.0f;

	public Material startColor;
	public Material endingColor;

	// Use this for initialization
	void Awake () 
	{
		positioning = transform.parent.parent.FindChild("lifebarPos").transform.position;

		transform.parent.position = positioning;

		this.enabled = true;
	}

	public void RecoverHealth()
	{
		renderer.material = startColor;
		transform.localScale = new Vector3(1.0f,1.0f,1.0f);
	}

	// Update is called once per frame
	public void GotDamage (float damage) 
	{
		if (transform.localScale.x > 0.0f)
		{
			energy-=damage;
			
			Vector3 energyVec = new Vector3(energy,1.0f,1.0f);
			transform.localScale = energyVec;
			
			if (transform.localScale.x < 0.3f)
				renderer.material = endingColor;
		}
		else
			transform.localScale = new Vector3(.0f,1.0f,1.0f);
	}
}
