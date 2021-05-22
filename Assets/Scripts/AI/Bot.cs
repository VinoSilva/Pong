using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bot
{
    public abstract float CalculateYPosition(BallController ballController, Vector3 ownPosition,float fMidDist,float fNearDist);
}
