using UnityEngine;
using System.Collections;

public class LevelBuilder : MonoBehaviour
{
    #region Difficulty

    public enum Difficulty { Easy, Medium, Hard }

    public Difficulty difficulty;

    #endregion

    #region Plataform Layout

    public enum PlataformLayout { Simple, Heights, Dynamic }

    public PlataformLayout plataformLayout;

    public Vector3 plataformOffset;

    #endregion

    #region Coins

    public int numberOfCoins;

    #endregion

    #region Enemies

    public int numberOfEnemies;

    #endregion

    #region Plataform

    public int numberOfPlataforms;

    public GameObject[] longPlataforms;

    public GameObject finalPlatform;

    #endregion

    #region Game Components

    Movimento player;

    Limite limite;

    PlatformEnd platformEnd;

    #endregion

    public void LevelCreator()
    {
        longPlataforms = new GameObject[numberOfPlataforms];

        switch(difficulty)
        {
            case Difficulty.Easy:
                plataformOffset = new Vector3(12.0f, 0.0f, 0.0f);
                break;
            case Difficulty.Medium:
                plataformOffset = new Vector3(13.0f, 0.0f, 0.0f);
                break;
            case Difficulty.Hard:
                plataformOffset = new Vector3(14.0f, 0.0f, 0.0f);
                break;
        }

        switch (plataformLayout)
        {
            case PlataformLayout.Simple:

                Debug.Log("Platform Single.");

                for (int i = 0; i <= numberOfPlataforms - 1; i++)
                {
                    longPlataforms[i] = Instantiate(Resources.Load<GameObject>("plataformLong"), plataformOffset*i, Quaternion.identity) as GameObject;
                    longPlataforms[i].name = "platformLong" + i;
                }

                finalPlatform = Instantiate(Resources.Load<GameObject>("plataformaFinal"), longPlataforms[numberOfPlataforms - 1].transform.position + plataformOffset/2.0f, 
                    Quaternion.identity) as GameObject;

                finalPlatform.AddComponent("PlatformEnd");

                break;

            case PlataformLayout.Heights:
                break;
            case PlataformLayout.Dynamic:
                break;
        }

        BackgroundConstrainCamera();

        createPlayer();

        CameraComponents();

        createLimite();

        AlignPlatformWithBackground();

        createEightCoins();
    }

    public void createPlayer()
    {
        player = Instantiate(GameCore.createGameScriptComponent(GameCore.GameComponentNames.Player), Vector3.zero, Quaternion.identity) as Movimento;
        player.gameObject.name = GameCore.GameComponentNames.Player.ToString();
    }

    public void BackgroundConstrainCamera()
    {
        GameObject background = new GameObject("Background");
        background.AddComponent("SpriteRenderer");
        background.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("beijing");

        background.transform.parent = Camera.main.transform;
    }

    public void CameraComponents()
    {
        GameObject startCamera = new GameObject("startCamera");
        startCamera.transform.position = Camera.main.transform.position;

        Camera.main.gameObject.AddComponent("AudioSource");

        Camera.main.transform.GetComponent<AudioSource>().loop = false;
        Camera.main.transform.GetComponent<AudioSource>().priority = 128;
        Camera.main.transform.GetComponent<AudioSource>().volume = 0.563f;
        Camera.main.transform.GetComponent<AudioSource>().pitch = 1;

        Camera.main.gameObject.AddComponent("CameraFollow");
        Camera.main.transform.GetComponent<CameraFollow>().startCamera = startCamera.transform;
        Camera.main.transform.GetComponent<CameraFollow>().player = GameObject.Find(GameCore.GameComponentNames.Player.ToString()).gameObject.GetComponent<Movimento>();
    }

    public void createLimite()
    {
       limite = Instantiate(GameCore.createGameScriptComponent(GameCore.GameComponentNames.Limite), new Vector3(0.0f, -7.0f, 0.0f), Quaternion.identity) as Limite;
       limite.gameObject.name = GameCore.RenameGameObject(limite.gameObject);
    }

    public void AlignPlatformWithBackground()
    {
        for (int i=0; i<= numberOfPlataforms-1; i++)
        {
            longPlataforms[i].transform.position += new Vector3(-7.0f, 0.0f, 0.0f);
        }

        finalPlatform.transform.position += new Vector3(-7.0f, 0.0f, 0.0f);
    }

    public void createEightCoins()
    {
        for (int i=0; i<= (numberOfCoins / 8)-1; i++)
        {
            Instantiate(Resources.Load<GameObject>("Coins8"), new Vector3(5.0f*i, 1.41f, 0.0f), Quaternion.identity);
        }
    }

    public void createGameplayManager()
    {
        
    }
}
