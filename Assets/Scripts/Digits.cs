using UnityEngine;
using System.Collections;

public class Digits : MonoBehaviour {

	#region Digits

	public Texture zero;

	public Texture one;

	public Texture two;

	public Texture three;
	
	public Texture four;

	public Texture five;
	
	public Texture six;

	public Texture seven;
	
	public Texture eight;

	public Texture nine;

	#endregion

	#region

	public Texture digit;

	#endregion
	
	void Start () 
	{
	}

	public Texture getDigit(int number)
	{
		Texture dig = zero;

		switch(number)
		{
		case 1:
			dig = one;
			break;
		case 2:
			dig = two;
			break;
		case 3:
			dig = three;
			break;
		case 4:
			dig = four;
			break;
		case 5:
			dig = five;
			break;
		case 6:
			dig = six;
			break;
		case 7:
			dig = seven;
			break;
		case 8:
			dig = eight;
			break;
		case 9:
			dig = nine;
			break;
		case 0:
			dig = zero;
			break;
		}
		
		return dig;
	}
}
