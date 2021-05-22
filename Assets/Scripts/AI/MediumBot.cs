using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBot : Bot
{
    public override float CalculateYPosition(BallController ballController, Vector3 ownPosition,float fMidDist,float fNearDist)
    {
        Vector2 Velocity = ballController.Velocity;

        float velocityX = Velocity.x;

        // This is to determine if the ball is moving towards the AI or not
        Vector3 dirBallVelocity = new Vector3(velocityX, 0.0f, 0.0f);
        Vector3 dirBallToPaddle = ownPosition - ballController.transform.position;
        float dot = Vector3.Dot(dirBallVelocity, dirBallToPaddle);

        // If ball moving away, then move towards the center
        float yPosition = 0.0f;

        if (dot > 0)
        {
            float dist = Vector3.Distance(ownPosition, ballController.transform.position);

            if (dist <= fNearDist)
            {
                yPosition = ballController.transform.position.y;
            }
            else if(dist <= fMidDist )
            {
                Vector2 A1 = (Vector2) ownPosition + Vector2.up * 10;
                Vector2 A2 = (Vector2) ownPosition + Vector2.up * -10;

                Vector2 ballPosition =(Vector2) ballController.transform.position;

                Vector2 B1 = ballPosition;
                Vector2 B2 = (Vector2) ballController.transform.position + Velocity.normalized *  20.0f;

                bool found = false;

                DebugExtension.DebugWireSphere(Math.GetIntersectionPointCoordinates(A1,A2,B1,B2,out found),Color.red,2.0f,Time.deltaTime);

                // if(found){
                // }
                // else{
                    yPosition = ballController.transform.position.y/2;
                // }
            }
            else //Far dist
            {
                yPosition = ballController.transform.position.y/2;
            }
        }

        return yPosition;
    }
}