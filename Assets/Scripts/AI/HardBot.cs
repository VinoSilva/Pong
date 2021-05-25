using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBot : Bot
{
    public HardBot(BallController ballController,AIController aiController):base(ballController,aiController){   
    }

    public override float CalculateYPosition()
    {
        throw new System.NotImplementedException();
    }
}