using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }
}
