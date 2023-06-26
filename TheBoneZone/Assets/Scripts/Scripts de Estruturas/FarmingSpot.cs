using System;
using UnityEngine;

[Serializable]
public class FarmingSpotData
{
    public Vector3 position;
    public Vector3 rotation;

}

public class FarmingSpotAdapter : FarmingSpotData
{
    public FarmingSpotAdapter(FarmingSpot fs)
    {
        position = fs.transform.position;
        rotation = fs.transform.rotation.eulerAngles;
    }
}

public class FarmingSpot : MonoBehaviour, IDataPersistance
{
    public int myId;

    void Awake()
    {
        ControlaListas.instance.farmingSpotList.Add(this);
        myId = ControlaListas.instance.farmingSpotList.IndexOf(this);
    }
    void Start()
    {
        SaveGame.instance.persistentObjects.Add(this);
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
        skeleton.isFarming = true;
        //skeleton.doingTask = true;
        skeleton.MoveTo(transform.position);
        //skeleton.ChangeState(skeleton.myStats.farmingState);
        UnitSelection.Instance.Deselect(skeleton);
        Ocupar();

        KeepCalling();
    }
    public void CallSkeleton(Skeleton skeleton)
    {

        skeleton.farmingSpot = this;
        skeleton.isFarming = true;
        //skeleton.doingTask = true;
        skeleton.MoveTo(transform.position);
        //skeleton.ChangeState(skeleton.myStats.farmingState);
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
        skeleton.isFarming = true;
        skeleton.doingTask = true;
        skeleton.MoveTo(farmingSpot.transform.position);
        //skeleton.ChangeState(skeleton.myStats.farmingState);
        UnitSelection.Instance.Deselect(skeleton);
        farmingSpot.Ocupar();

        KeepCalling();
    }

    #endregion

    void OnDestroy()
    {
        ControlaListas.instance.farmingSpotList.Remove(this);
    }

    public void SaveData(ref SceneData data)
    {
        data.farmingSpots.Add(new FarmingSpotAdapter(this));
    }
}
