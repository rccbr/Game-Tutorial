using UnityEngine;
using System.Collections;

public static class GameCore
{
    #region Game Component Names

    public enum GameComponentNames {Player, PlatformEnd, Monstar, GameplayManager, Limite}

    public enum GameObjectNames {PlatformShort, PlatformLong}

    #endregion

    public static MonoBehaviour createGameScriptComponent(GameComponentNames entity)
    {
        MonoBehaviour gameEntity;

        switch (entity)
        {
            case GameComponentNames.Player:

                gameEntity = Resources.Load<Movimento>(GameComponentNames.Player.ToString());
                break;

            case GameComponentNames.Monstar:

                gameEntity = Resources.Load<Monstar>(GameComponentNames.Monstar.ToString());
                break;

            case GameComponentNames.PlatformEnd:

                gameEntity = Resources.Load<PlatformEnd>(GameComponentNames.PlatformEnd.ToString());
                break;

            case GameComponentNames.Limite:

                gameEntity = Resources.Load<Limite>(GameComponentNames.Limite.ToString());
                break;

            default:

                gameEntity = null;
                break;
        }

        return gameEntity;
    }

    public static GameObject createGameObject(GameObjectNames gameObject)
    {
        GameObject gameObj;

        switch (gameObject)
        {
            case GameObjectNames.PlatformShort:

                gameObj = Resources.Load<GameObject>(GameObjectNames.PlatformShort.ToString());
                break;

            case GameObjectNames.PlatformLong:

                gameObj = Resources.Load<GameObject>(GameObjectNames.PlatformShort.ToString());
                break;

            default:

                gameObj = null;
                break;
        }

        return gameObj;
    }

    public static string RenameGameObject(GameObject gameObj)
    {
        if (gameObj.name.Contains("(Clone)"))
        {
            char[] charsToTrim = { '(', 'C', 'l', 'o', 'n', 'e', ')' };
            gameObj.name.Trim(charsToTrim);
            Debug.Log(gameObj.name);
        }

        return gameObj.name;
    }
}
