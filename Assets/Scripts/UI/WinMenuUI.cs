using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenuUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private Text victoryTxt = null;

    [SerializeField]
    private Button playAgainBtn = null;

    [SerializeField]
    private Button mainMenuBtn = null;

    [SerializeField]
    private Button quitGameBtn = null;

    [Header("Scriptable Variable References")]
    [SerializeField]
    private IntVariable playerOneScore = null;

    [SerializeField]
    private IntVariable playerTwoScore = null;

    [Header("Game Events")]
    [SerializeField]
    private GameEvent onGameRestart = null;

    private void Start()
    {
        playAgainBtn.onClick.AddListener (OnClickPlayAgain);
        mainMenuBtn.onClick.AddListener (OnClickMainMenu);
        quitGameBtn.onClick.AddListener (OnClickQuit);
    }

    private void OnClickPlayAgain()
    {
        onGameRestart.Raise();
    }

    private void OnClickMainMenu()
    {
        Time.timeScale = 1.0f;
        LevelManager.LoadLevel(0);
    }

    private void OnClickQuit()
    {
        LevelManager.QuitGame();
    }

    public void OnGameFinished()
    {
        if (playerOneScore.RuntimeValue > playerTwoScore.RuntimeValue)
        {
            victoryTxt.text = "Player One Won";
        }
        else
        {
            switch (GameSession.Instance.GameMode)
            {
                case GameMode.OnePlayer:
                    victoryTxt.text = "Bot Won";
                    break;
                case GameMode.TwoPlayer:
                    victoryTxt.text = "Player Two Won";
                    break;
            }
        }
    }
}
