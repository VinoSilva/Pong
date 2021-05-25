using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DifficultyMenuUI : MonoBehaviour
{
    [Header("References Variable")]
    [SerializeField]
    private Button easyBtn = null;

    [SerializeField]
    private Button mediumBtn = null;

    [SerializeField]
    private Button hardBtn = null;

    [SerializeField]
    private Button backBtn = null;

    [SerializeField]
    private MainMenuUI mainMenuUI = null;

    private void Start() {
        easyBtn.onClick.AddListener(()=>{StartGame(GameDifficulty.Easy);});
        mediumBtn.onClick.AddListener(()=>{StartGame(GameDifficulty.Medium);});
        hardBtn.onClick.AddListener(()=>{StartGame(GameDifficulty.Hard);});
        backBtn.onClick.AddListener(OnClickBack);
    }

    private void OnEnable() {
        easyBtn.gameObject.SetActive(true);
        easyBtn.Select();
        EventSystem.current.SetSelectedGameObject(null);    
        EventSystem.current.SetSelectedGameObject(easyBtn.gameObject,null);
    }

    private void StartGame(GameDifficulty gameDifficulty = GameDifficulty.Easy){
        GameSession.Instance.SetGameDifficulty(gameDifficulty);
        LevelManager.LoadLevel(1);
    }

    private void OnClickBack(){
        mainMenuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
