using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [Header("Button References Variable")]
    [SerializeField]
    private Button resumeBtn = null;

    [SerializeField]
    private Button mainMenuBtn = null;

    [SerializeField]
    private Button quitBtn = null;

    [Header("Game Event References Variable")]
    [SerializeField]
    private GameEvent onResumeEvent = null;

    private void Start()
    {
        resumeBtn.onClick.AddListener (OnResumeClick);
        mainMenuBtn.onClick.AddListener (OnMainMenuClick);
        quitBtn.onClick.AddListener (OnQuitClick);
    }

    private void OnEnable()
    {
        resumeBtn.gameObject.SetActive(true);
        resumeBtn.Select();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeBtn.gameObject, null);
    }

    private void OnResumeClick()
    {
        onResumeEvent.Raise();
    }

    private void OnMainMenuClick()
    {
        onResumeEvent.Raise();
        LevelManager.LoadLevel(0);
    }

    private void OnQuitClick()
    {
        LevelManager.QuitGame();
    }
}
