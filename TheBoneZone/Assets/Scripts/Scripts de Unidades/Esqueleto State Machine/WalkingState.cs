using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : SkeletonState
{
    public override void DoState(Skeleton skeleton)
    {
        if (skeleton.walking)
        {
            skeleton.stateInitialized = false;
            skeleton.agent.speed = skeleton.myStats.maxMovespeed * (skeleton.tirednessCoefficient * 2);
            return;
        }
        if (skeleton.doingTask)
        {
            skeleton.stateInitialized = false;
            return;
        }

        if (!skeleton.stateInitialized)
        {
            skeleton.stateInitialized = true;
            skeleton.ChangeAnimationState("Idle");
            skeleton.ChangeState(skeleton.myStats.idleState);
        }
    }

}
