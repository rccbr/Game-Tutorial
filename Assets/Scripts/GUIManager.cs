using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	#region GUI Coins

	public DigitsCoins coinsUI;

	public bool achievedHundredCoins = false;

	#endregion

	#region GUI Life

	public bool winLife = false;

	public bool loseLife = false;

	public LifeDigits lifeDigits;

	#endregion

    #region Pause Menu

    public PauseMenu pauseMenu;

    #endregion


    public void AssignNewWindow()
    {
        pauseMenu = GameObject.Find("PauseWindow").gameObject.GetComponent<PauseMenu>();

        pauseMenu.paused = true;
    }
}
