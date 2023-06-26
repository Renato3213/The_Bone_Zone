using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkeletonState 
{
    void OnEnter(Skeleton skeleton);
    void OnExit();
    void OnUpdate();
}
