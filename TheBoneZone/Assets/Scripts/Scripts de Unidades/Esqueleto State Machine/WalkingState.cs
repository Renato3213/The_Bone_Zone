using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : SkeletonState
{
    bool initiated;
    public override void DoState(Skeleton skeleton)
    {
        Debug.Log("walking");
        if (skeleton.walking)
        {
            initiated = false;
            return;
        }
        if (skeleton.doingTask)
        {
            initiated = false;
            return;
        }

        if (!initiated)
        {
            initiated = true;
            skeleton.ChangeAnimationState("Idle");
            skeleton.currentState = skeleton.idleState;
        }
    }

}
