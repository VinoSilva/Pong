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

    [SerializeField]
    [Range(0.0f,30.0f)]
    private float fNearDist = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move(){
        BallController ballController = BallManager.Instance.BallController;

        if (!ballController)
        {
            return;
        }

        Vector2 Velocity = ballController.Velocity;
        
        float velocityX = Velocity.x;

        Vector3 dirBallVelocity = new Vector3(velocityX,0.0f,0.0f);

        Vector3 dirToPaddle = transform.position - ballController.transform.position;

        float dot = Vector3.Dot(dirBallVelocity,dirToPaddle);

        float yPosition = 0.0f;

        if(dot > 0){
            float dist = Vector3.Distance(transform.position,ballController.transform.position);

            if(dist <= fNearDist){
                yPosition = ballController.transform.position.y;
            }
            else{
                yPosition = ballController.transform.position.y/2;
            }
        }

        float yDifference = yPosition - transform.position.y;

        Vector2 moveDir = Vector2.up * (yDifference);

        if(Mathf.Abs(yDifference) > 0.5f){
            rbBody.MovePosition((Vector2)transform.position + (moveDir.normalized *Time.deltaTime*fMoveSpeed));
        }
        else{
            rbBody.MovePosition((Vector2)transform.position + (moveDir *Time.deltaTime));
        }
    }
}
