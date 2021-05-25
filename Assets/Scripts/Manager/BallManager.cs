using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefBall = null;

    private GameObject ball = null;

    public GameObject Ball { get => ball; private set => ball = value; }

    private BallController ballController = null;
    public BallController BallController { get => ballController; private set => ballController = value; }

    private static BallManager _instance;

    public static BallManager Instance {get {return _instance;}}


    [Header("Timer variables")]
    [SerializeField]
    [Range(0.0f,4.0f)]
    [Tooltip("Time to spawn the ball")]
    private float fTimerMax = 3.0f;

    private void Awake() {
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        }
        else{
            SpawnBall();
            ball.SetActive(false);
            
            _instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(ISpawnBall());
    }

    private void OnDestroy() {
        // Remove reference to this instance, so that it is collected by garbage collector
        if(this == _instance){
            _instance = null;
        }
    }

    private void SpawnBall()
    {
        if (!Ball)
        {
            Ball = Instantiate(prefBall,Vector3.zero,prefBall.transform.rotation) as GameObject;
            ballController = Ball.GetComponent<BallController>();
        }
    }

    private void Reset()
    {
        if (!Ball.gameObject.activeSelf)
        {
            Ball.transform.position = Vector3.zero;
            Ball.SetActive(true);
        }
    }

    private IEnumerator ISpawnBall()
    {
        yield return new WaitForSecondsRealtime(fTimerMax);

        SpawnBall();
        Reset();

        yield return null;
    }

    public void OnGoalScored(){
        StartCoroutine(ISpawnBall());
    }

    public void OnGameFinished(){
        Ball.SetActive(false);
        StopAllCoroutines();
    }

    public void OnGameRestart(){
        StartCoroutine(ISpawnBall());
    }
}
