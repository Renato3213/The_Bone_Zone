using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingSpot : MonoBehaviour
{
    void Awake()
    {
        ControlaListas.instance.farmingSpotList.Add(this);
    }

    public void Ocupar()
    {
        ControlaListas.instance.farmingSpotList.Remove(this);
    }

    public void Desocupar()
    {
        ControlaListas.instance.farmingSpotList.Add(this);
    }

    #region Calling Methods

    void OnMouseOver()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;

        if (Input.GetMouseButtonDown(1))
        {
            CallSkeleton();
        }
    }

    void CallSkeleton()
    {
        Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];

        skeleton.farmingSpot = this;
        skeleton.doingTask = true;
        skeleton.MoveTo(transform.position);
        skeleton.ChangeState(skeleton.myStats.farmingState);
        UnitSelection.Instance.Deselect(skeleton);
        Ocupar();

        KeepCalling();
    }

    void KeepCalling()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;

        Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];
        FarmingSpot farmingSpot = ControlaListas.instance.farmingSpotList[0];

        skeleton.farmingSpot = farmingSpot;
        skeleton.doingTask = true;
        skeleton.MoveTo(farmingSpot.transform.position);
        skeleton.ChangeState(skeleton.myStats.farmingState);
        UnitSelection.Instance.Deselect(skeleton);
        farmingSpot.Ocupar();

        KeepCalling();
    }

    #endregion

    void OnDestroy()
    {
        ControlaListas.instance.farmingSpotList.Remove(this);
    }
    
}
