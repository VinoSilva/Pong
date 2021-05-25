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

    private Tweener punchTweenOne = null;
    private Tweener punchTweenTwo = null;

    public void OnGoalScored(){
        playerOneScoreText.text = playerOneScore.RuntimeValue.ToString();
        playerTwoScoreText.text = playerTwoScore.RuntimeValue.ToString();

        if(punchTweenOne == null){
            punchTweenOne = playerOneScoreText.gameObject.transform.DOPunchScale(Vector3.one,1.0f).SetAutoKill(false);
        }
        else{
            punchTweenOne.Restart();
        }

        if(punchTweenTwo == null){
            punchTweenTwo = playerTwoScoreText.gameObject.transform.DOPunchScale(Vector3.one,1.0f).SetAutoKill(false);
        }
        else{
            punchTweenTwo.Restart();
        }
    }

    public void OnGameRestart(){
        
        if(punchTweenOne != null){
            punchTweenOne.Rewind();
        }

        if(punchTweenTwo != null){
            punchTweenTwo.Rewind();
        }

        playerOneScoreText.text = "0";
        playerTwoScoreText.text = "0";
    }
}
