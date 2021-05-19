using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    OnePlayer,
    TwoPlayer
}

public class GameSession : MonoBehaviour
{
    private static GameSession _instance;

    private GameMode gameMode = GameMode.OnePlayer;
    public GameMode GameMode { get => gameMode; private set => gameMode = value; }

    public static GameSession Instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad (gameObject);
            _instance = this;
        }
    }

    public void SetGameMode(GameMode newGameMode)
    {
        gameMode = newGameMode;
    }
}
