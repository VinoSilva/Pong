using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("References Variable")]
    [SerializeField]
    private Button playBtn = null;

    [SerializeField]
    private Button quitBtn = null;

    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener (Play);
        quitBtn.onClick.AddListener (Quit);
    }

    private void Play()
    {
        LevelManager.LoadLevel(1);
    }

    private void Quit()
    {
        LevelManager.QuitGame();
    }
}
