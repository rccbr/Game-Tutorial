using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	#region GameState

	public enum GameState {Playing, NotPlaying, GameOver, Win, Restart};
	
	public GameState gameState;

	#endregion

	#region UIManager Instance

	public GUIManager guiManager;

	#endregion 

	#region GamePlay Elements

	public PlatformEnd platformEnd;
	
	public Limite limite;
	
	public Movimento player;

	public CameraFollow camera;

	#endregion

	#region Game Conditions Scene Flow

	public string Win;
	public string GameOver;

	#endregion

	#region RunOnce

	private bool loseLife = true;

	#endregion

	#region Spawn Player

	public Transform spawnPlayer;

	#endregion

	#region NumberOfCoins

	public GameObject numberCoins;

	#endregion

	#region Gameplay Handle Events

	ArrayList listGameObject;

	public bool processOnce = false;

	#endregion

	public delegate void ProcessGameplayEvent(GameObject go);

	void Awake()
	{
		listGameObject = new ArrayList();
	}

	// Use this for initialization
	void Start () 
	{
		guiManager.lifeDigits.lifeCount = player.life;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Victory
		if (platformEnd.gameEnd)
			gameState = GameState.Win;

		if (gameState == GameState.Win)
			Application.LoadLevel(Win);

		if (player.died || limite.heroDied)
		{

			//Player died falling

			if (player.life > 0)
			{
				gameState = GameState.Restart;
				guiManager.lifeDigits.lifeCount = --(player.life);
				player.stopInput  = false;
				player.facingRight = true;
			}

			if (player.life == 0)
			{
				gameState = GameState.GameOver;
				player.stopInput  = false;
			}
		}

		//its game over
		if (gameState == GameState.GameOver)
			Application.LoadLevel(GameOver);

		if (player.gotCoin)
		{
			guiManager.coinsUI.count++;
			player.gotCoin = false;
		}

		if (gameState == GameState.Restart)
		{
			player.gameObject.transform.position = spawnPlayer.position;
			limite.heroDied = false;
			player.died = false;
			player.RecoverComponents();
			player.lifeBar.energy = 1.0f;
			player.lifeBar.RecoverHealth();
			player.checkDied = true;
			camera.moveToStart = true;

			StartCoroutine("waitUntilCameraReachStart");

			gameState = GameState.Playing;
		}

		if (!processOnce)
		{
			addGameObjectEventToBeProcessed(player.gameObject);
			processEvents();
			processOnce = true;
		}

        if (guiManager.pauseMenu)
        {
            if (guiManager.pauseMenu.paused)
            {
                player.Stop();
            }
            else
                player.Resume();
        }
	}

    void FindGameComponents()
    {
        player = GameObject.Find("Player").GetComponent<Movimento>();
    }

	public void addGameObjectEventToBeProcessed(GameObject gameobject)
	{
		listGameObject.Add(gameobject);
	}

	public void processEvents()
	{
		StartCoroutine(IdentifyGameEntities(new ProcessGameplayEvent(player.printName)));
	}

	IEnumerator waitUntilCameraReachStart()
	{
		Debug.Log("Camera Reach Start");

		yield return new WaitForSeconds(5.0f);

		camera.moveToStart = false;
	}

	IEnumerator IdentifyGameEntities(ProcessGameplayEvent gameplayEvent)
	{
		yield return new WaitForSeconds(1.0f);

		foreach (GameObject gameObj in listGameObject)
		{
			gameplayEvent(gameObj);
		}
	}
}
