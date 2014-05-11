using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    #region Reference Button Event

    public ButtonEvent ResumeBt;

    public ButtonEvent OptionsBt;

    #endregion

    #region Animator

    private Animator anim;

    #endregion

    #region Pause booleans

    public bool paused = false;

    #endregion

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (ResumeBt.OnClicked())
        {
            anim.SetBool("unpause", true);

            StartCoroutine("playAnimationAndDestroy");

            paused = false;
        }
            
	}

    IEnumerator playAnimationAndDestroy()
    {
        yield return new WaitForSeconds(1.0f);

        Window.DestroyWindow(GameObject.Find(Window.GetWindowTypeName(Window.WindowType.PauseWindow)));
    }
}
