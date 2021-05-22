using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("References Variabel")]
    [SerializeField]
    private Rigidbody2D rbBody = null;

    [SerializeField]
    [Range(0.0f, 30.0f)]
    private float fMoveSpeed = 0.0f;

    [Header("Distance Variables")]
    [SerializeField]
    [Range(0.0f, 30.0f)]
    private float fMidDist = 0.0f;

    [SerializeField]
    [Range(0.0f, 30.0f)]
    private float fNearDist = 0.0f;

    private Bot bot = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fMidDist);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, fNearDist);
    }

    private void OnEnable()
    {
        if (bot == null)
        {
            InitializeBot();
        }
    }

    private void InitializeBot()
    {
        switch (GameSession.Instance.GameDifficulty)
        {
            case GameDifficulty.Easy:
                Debug.Log("Easy Bot");
                bot = new EasyBot();
                break;
            case GameDifficulty.Medium:
                Debug.Log("Medium Bot");
                bot = new MediumBot();
                break;
            case GameDifficulty.Hard:
                Debug.Log("Hard Bot");
                bot = new HardBot();
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        BallController ballController = BallManager.Instance.BallController;

        if (!ballController)
        {
            return;
        }

        float yPosition =
            bot
                .CalculateYPosition(ballController,
                transform.position,
                fMidDist,
                fNearDist);

        float yDifference = yPosition - transform.position.y;

        Vector2 moveDir = Vector2.up * (yDifference);

        if (Mathf.Abs(yDifference) > 0.5f)
        {
            rbBody
                .MovePosition((Vector2) transform.position +
                (moveDir.normalized * Time.deltaTime * fMoveSpeed));
        }
        else
        {
            rbBody
                .MovePosition((Vector2) transform.position +
                (moveDir * Time.deltaTime));
        }
    }
}
