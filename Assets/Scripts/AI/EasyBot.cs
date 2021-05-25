using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBot : Bot
{
    public EasyBot(BallController ballController,AIController aiController):base(ballController,aiController){   
    }

    public override float CalculateYPosition()
    {
        // If ball moves, away then head to center
        float yPosition = 0.0f;

        if (isBallHeadingToSelf())
        {
            float dist = Vector3.Distance(aiController.transform.position, ballController.transform.position);

            // If ball move towards, if the distance is near than fMidDist then head to exact position.
            if (dist <= aiController.FMidDist)
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
