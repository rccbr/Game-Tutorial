using UnityEngine;
using System.Collections;

public class Stoppable : MonoBehaviour
{
    public bool stop = false;

	public void Stop()
    {
        stop = true;
    }

    public void Resume()
    {
        stop = false;
    }
}
