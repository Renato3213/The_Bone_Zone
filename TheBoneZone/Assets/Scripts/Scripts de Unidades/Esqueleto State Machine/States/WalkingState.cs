using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : ISkeletonState
{
    //public override void DoState(Skeleton skeleton)
    //{
    //    if (skeleton.walking)
    //    {
    //        skeleton.stateInitialized = false;
    //        skeleton.agent.speed = skeleton.myStats.maxMovespeed * (skeleton.tirednessCoefficient * 2);
    //        return;
    //    }
    //    if (skeleton.doingTask)
    //    {
    //        skeleton.stateInitialized = false;
    //        return;
    //    }

    //    if (!skeleton.stateInitialized)
    //    {
    //        skeleton.stateInitialized = true;
    //        skeleton.ChangeAnimationState("Idle");
    //        skeleton.ChangeState(skeleton.myStats.idleState);
    //    }
    //}

    Skeleton mySkeleton;

    public void OnEnter(Skeleton skeleton)
    {
        mySkeleton = skeleton;
        mySkeleton.reseted = false;
        mySkeleton.agent.speed = mySkeleton.myStats.maxMovespeed * (mySkeleton.tirednessCoefficient * 2);
        mySkeleton.agent.isStopped = false;
        mySkeleton.ChangeAnimationState("Walk");
    }

    public void OnExit()
    {
        mySkeleton.ChangeAnimationState("Idle");
        mySkeleton.agent.isStopped = true;
    }

    public void OnUpdate()
    {
        
    }
}
