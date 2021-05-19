using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("References Variable")]
    [SerializeField]
    private Button playOnePlayerBtn = null;

    [SerializeField]
    private Button playTwoPlayerBtn = null;

    [SerializeField]
    private Button quitBtn = null;

    // Start is called before the first frame update
    void Start()
    {
        playOnePlayerBtn.onClick.AddListener (StartOnePlayerGame);
        playTwoPlayerBtn.onClick.AddListener (StartTwoPlayerGame);
        quitBtn.onClick.AddListener (Quit);
    }

    private void StartOnePlayerGame()
    {
        GameSession.Instance.SetGameMode(GameMode.OnePlayer);
        LevelManager.LoadLevel(1);
    }

    private void StartTwoPlayerGame()
    {
        GameSession.Instance.SetGameMode(GameMode.TwoPlayer);
        LevelManager.LoadLevel(1);
    }

    private void Quit()
    {
        LevelManager.QuitGame();
    }
}
