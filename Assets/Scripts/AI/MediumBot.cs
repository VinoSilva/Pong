using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBot : Bot
{
    public MediumBot(BallController ballController,AIController aiController):base(ballController,aiController){   
    }

    public override float CalculateYPosition()
    {
        Vector2 Velocity = ballController.Velocity;

        // If ball moving away, then move towards the center
        float yPosition = 0.0f;

        if (isBallHeadingToSelf())
        {
            float dist = Vector3.Distance(aiController.transform.position, ballController.transform.position);

            if (dist <= aiController.FNearDist)
            {
                yPosition = ballController.transform.position.y;
            }
            else if(dist <= aiController.FMidDist )
            {
                Vector2 A1 = (Vector2) aiController.transform.position + Vector2.up * 10;
                Vector2 A2 = (Vector2) aiController.transform.position + Vector2.up * -10;

                Vector2 ballPosition =(Vector2) ballController.transform.position;

                Vector2 B1 = ballPosition;
                Vector2 B2 = (Vector2) ballController.transform.position + Velocity.normalized *  20.0f;

                bool found = false;

                Vector2 movePosition = Math.GetIntersectionPointCoordinates(A1,A2,B1,B2,out found);

                DebugExtension.DebugWireSphere(movePosition,Color.red,2.0f,Time.deltaTime);

                if(found){
                    yPosition = movePosition.y;
                }
                else{
                    yPosition = ballController.transform.position.y/2;
                }
            }
            else //Far dist
            {
                yPosition = ballController.transform.position.y/2;
            }
        }

        return yPosition;
    }
}