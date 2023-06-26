using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ISkeletonState
{
    //public override void DoState(Skeleton skeleton)
    //{
    //    //nada
    //}

    public void OnEnter(Skeleton skeleton)
    {
        skeleton.ChangeAnimationState("Idle");
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        
    }

}
