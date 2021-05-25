using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bot
{
    protected BallController ballController = null;

    protected AIController aiController = null;

    public Bot(BallController ballController,AIController aiController){
        this.ballController = ballController;
        this.aiController = aiController;
    }

    public abstract float CalculateYPosition();

    protected bool isBallHeadingToSelf(){
        Vector2 Velocity = ballController.Velocity;

        float velocityX = Velocity.x;

        // This is to determine if the ball is moving towards the AI or not
        Vector3 dirBallVelocity = new Vector3(velocityX, 0.0f, 0.0f);
        Vector3 dirBallToPaddle = aiController.transform.position - ballController.transform.position;
        float dot = Vector3.Dot(dirBallVelocity, dirBallToPaddle);

        return dot > 0;
    }
}