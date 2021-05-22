using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBot : Bot
{
    public EasyBot()
    {
    }

    public override float CalculateYPosition(BallController ballController, Vector3 ownPosition, float fMidDist, float fNearDist)
    {

        Vector2 Velocity = ballController.Velocity;

        float velocityX = Velocity.x;

        // This is to determine if the ball is moving towards the AI or not
        Vector3 dirBallVelocity = new Vector3(velocityX, 0.0f, 0.0f);
        Vector3 dirBallToPaddle = ownPosition - ballController.transform.position;
        float dot = Vector3.Dot(dirBallVelocity, dirBallToPaddle);

        // If ball moves, away then head to center
        float yPosition = 0.0f;

        if (dot > 0)
        {
            float dist = Vector3.Distance(ownPosition, ballController.transform.position);

            // If ball move towards, if the distance is near than fMidDist then head to exact position.
            if (dist <= fMidDist)
            {
                yPosition = ballController.transform.position.y;
            }
            else //If ball move towards, if it is further then move to mid point of self y position and ball's y position.
            {
                yPosition = ballController.transform.position.y / 2;
            }
        }

        return yPosition;
    }
}
