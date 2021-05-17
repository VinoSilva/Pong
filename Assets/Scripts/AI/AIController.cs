using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("References Variabel")]
    [SerializeField]
    private Rigidbody2D rbBody = null;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float yDamping = 0.0f;

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

        if(dot <= 0){
            MoveToCenter();
        }
        else{
            FollowBall(ballController);    
        }
    }

    void FollowBall(BallController ballController)
    {
        float yPosition = Mathf.Lerp(transform.position.y,ballController.transform.position.y,Time.deltaTime * yDamping);

        rbBody.MovePosition(new Vector2(transform.position.x,yPosition));
    }

    void MoveToCenter(){
        float yPosition = Mathf.Lerp(transform.position.y,0.0f,Time.deltaTime * yDamping);
        
        rbBody.MovePosition(new Vector2(transform.position.x,yPosition));
    }
}
