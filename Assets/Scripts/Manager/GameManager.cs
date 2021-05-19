using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scriptable Variables")]
    [SerializeField]
    private BoolVariable pauseVariable = null;

    [Header("Game Event")]
    [SerializeField]
    private GameEvent onGameStart = null;

    [SerializeField]
    private GameEvent onGameFinished = null;

    private static GameManager _instance;

    [Header("Scriptable Variable")]
    [SerializeField]
    private IntVariable playerOneScore = null;

    [SerializeField]
    private IntVariable playerTwoScore = null;

    [Header("Game Setting")]
    [SerializeField]
    private GameSetting gameSetting = null;

    public static GameManager Instance
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
            _instance = this;
        }
    }

    private void OnEnable() {
        onGameStart.Raise();
    }

    private void OnDestroy()
    {
        // Remove reference to this instance, so that it is collected by garbage collector
        if (this == _instance)
        {
            _instance = null;

            if (pauseVariable)
            {
                pauseVariable.RuntimeValue = false;
            }
        }
    }

    public void OnPaused()
    {
        pauseVariable.RuntimeValue = true;
        Time.timeScale = 0.0f;
    }

    public void OnResume()
    {
        pauseVariable.RuntimeValue = false;
        Time.timeScale = 1.0f;
    }
    public void OnGameRestart(){
        OnResume();

        playerOneScore.RuntimeValue = 0;
        playerTwoScore.RuntimeValue = 0;
    }
    
    public void OnGoalScored()
    {
        if( playerOneScore.RuntimeValue >= gameSetting.maxScore || playerTwoScore.RuntimeValue  >= gameSetting.maxScore)
        {   
            onGameFinished.Raise();
        }
    }

}
