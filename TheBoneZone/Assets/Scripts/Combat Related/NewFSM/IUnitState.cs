using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitState 
{
    void OnEnter();
    void OnExit();
    void OnUpdate();
}
