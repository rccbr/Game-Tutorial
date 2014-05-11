using UnityEngine;
using System.Collections;

public class CoinItem : MonoBehaviour {

	public AudioClip coinSound;
	
	void Start () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			if (!audio.isPlaying)
			{
				audio.clip = coinSound;
				audio.Play();
			}

			Destroy (GetComponent<SpriteRenderer>());
			Destroy(GetComponent<CircleCollider2D>());

			StartCoroutine("waitUntilSoundStops");
		}
	}

	IEnumerator waitUntilSoundStops()
	{
		Debug.Log("waitUntilSoundStops");

		yield return new WaitForSeconds(audio.clip.length);

		Destroy(this.gameObject);
	}
}
