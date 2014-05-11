using UnityEngine;
using System.Collections;

public class LogoIntro : MonoBehaviour {

	void Start () 
    {
        StartCoroutine("startFadeIn");
	}

    IEnumerator startFadeIn()
    {
        for (float f = 0.0f; f <= 1.0f; f+= 0.025f)
        {
            camera.backgroundColor = Color.Lerp(Color.black, Color.white, f);

            yield return null;

            if (f >= 0.99f)
                StartCoroutine("startFadeOut");
        }
    }

    IEnumerator startFadeOut()
    {
        yield return new WaitForSeconds(3.0f);

        for (float f = 0.0f; f <= 1.0f; f += 0.025f)
        {
            camera.backgroundColor = Color.Lerp(Color.white, Color.black, f);

            yield return null;
        }

        GameApp.Load("Main Menu");
    }
}
