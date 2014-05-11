using UnityEngine;
using System.Collections;

public class DigitsCoins : MonoBehaviour {

	#region Digits

	public Texture digitOne;

	public Texture digitTwo;

	public Texture digitThree;

	#endregion

	#region Count

	public int count = 11;

	#endregion 

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (count < 10)
		{
			digitOne = GetComponent<Digits>().getDigit(0);
			digitTwo = GetComponent<Digits>().getDigit(count);
		}

		if (count >= 10 && count <= 99)
		{
			int digitDezene = count/10;
			digitOne = GetComponent<Digits>().getDigit(digitDezene);
			digitTwo = GetComponent<Digits>().getDigit(count-(digitDezene*10));
		}

		if (count == 100)
		{
			digitOne = GetComponent<Digits>().getDigit(1);
			digitTwo = GetComponent<Digits>().getDigit(0);
			digitThree = GetComponent<Digits>().getDigit(0);
		}

		Feed();
	}

	void Feed()
	{
		transform.FindChild("digitOne").GetComponent<GUITexture>().texture = digitOne;
		transform.FindChild("digitTwo").GetComponent<GUITexture>().texture =digitTwo;
		transform.FindChild("digitThree").GetComponent<GUITexture>().texture= digitThree;
	}

}


