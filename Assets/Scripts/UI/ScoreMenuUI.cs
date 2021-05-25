using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreMenuUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private Text playerOneScoreText = null;

    [SerializeField]
    private Text playerTwoScoreText = null;
    
    [Header("Scriptable Variable")]
    [SerializeField]
    private IntVariable playerOneScore = null;

    [SerializeField]
    private IntVariable playerTwoScore = null;

    public void OnGoalScored(){
        playerOneScoreText.text = playerOneScore.RuntimeValue.ToString();
        playerTwoScoreText.text = playerTwoScore.RuntimeValue.ToString();

        playerOneScoreText.gameObject.transform.DOPunchScale(Vector3.one,1.0f);
        playerTwoScoreText.gameObject.transform.DOPunchScale(Vector3.one,1.0f);
    }

    public void OnGameRestart(){
        playerOneScoreText.text = "0";
        playerTwoScoreText.text = "0";
    }
}
