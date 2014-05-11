using UnityEngine;
using System.Collections;

public class OneDigit : MonoBehaviour {

	#region Digits
	
	public Texture zero;

	public Texture one;
	
	public Texture two;
	
	public Texture three;

	#endregion

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	public Texture getDigit (int number) 
	{
		Texture dig = zero;

		switch(number)
		{
			case 0:
				dig = zero;
				break;
			case 1:
				dig = one;
				break;
			case 2:
				dig = two;
				break;
			case 3:
				dig = three;
				break;
		}

		return dig;
	}
}
