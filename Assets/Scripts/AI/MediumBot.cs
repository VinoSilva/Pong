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

            // if(dist > aiController.FMidDist) //Far dist
            if(Mathf.Abs(aiController.transform.position.x - ballController.transform.position.x) > aiController.FMidDist) //Far dist
            {
                Debug.Log("Head towards ball half y position");
                yPosition = ballController.transform.position.y/2;
            }
            else
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
                    Debug.Log("Head towards intersection y position");

                    yPosition = movePosition.y;
                }
                else{
                    Debug.Log("Head towards ball half y position. No intersection");
                    yPosition = ballController.transform.position.y/2;
                }
            }
        }

        Vector3 pos = aiController.transform.position;
        pos.y = yPosition;

        DebugExtension.DebugWireSphere(pos,Color.cyan,0.5f,0.02f);

        return yPosition;
    }
}