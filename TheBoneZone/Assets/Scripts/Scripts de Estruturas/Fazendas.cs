using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class GrinderData
{
    public Vector3 position;
    public Vector3 rotation;
    public float bonesStored;
    public int workingHere;
}

public class GrinderAdapter : GrinderData
{
    public GrinderAdapter(Fazendas grinder)
    {
        position = grinder.transform.position;
        rotation = grinder.transform.rotation.eulerAngles;
        bonesStored = grinder.bonesStored;
        workingHere = 0;
    }
}

public class Fazendas : MonoBehaviour, IDataPersistance
{
    //public int quantidadeEsqueletos;
    //public float producao;
    //public float tempo;
    [Header("Status")]
    [Space]
    public StructureFlyweight myStats;

    public float bonesStored;

    public Transform entrada, saida;

    [Space]
    [Header("Interface Related")]
    [Space]
    public InterfaceFazenda myInterface;


    [HideInInspector]
    public int workingHere;
    public List<Skeleton> trabalhandoAqui = new List<Skeleton>();
    public int myId;

    void Awake()
    {
        GameManager.instance.listManager.grindersList.Add(this);
        myId = GameManager.instance.listManager.grindersList.IndexOf(this);
    }
    void Start()
    {
        SaveGame.instance.persistentObjects.Add(this);
        myInterface.Atualiza();
    }

    void OnMouseOver()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;
        if (Input.GetMouseButtonDown(1))
        {
            ChamarEsqueletos();
        }
    }
    void OnMouseDown()
    {
        GameManager.instance.UpdateActiveInterface(myInterface.gameObject);
        myInterface.Atualiza();
    }

    public void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;


        if(workingHere < myStats.grinderSkeletonLimit)
        {

            GrindCommand();
            ChamarEsqueletos();
        }
        else
        {
            if (ControlaListas.instance.farmingSpotList.Count == 0) return;

            FarmCommand();
            ChamarEsqueletos();
        }
    }

    public void GrindCommand() //sends skeleton to grind on that farm
    {
        Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];

        skeleton.MoveTo(entrada.position);
        skeleton.isGrinding = true;
        skeleton.grinderTarget = this;
        //keleton.doingTask = true;
        //skeleton.ChangeState(skeleton.myStats.grindingState);
        UnitSelection.Instance.Deselect(skeleton);
        
    }

    public void FarmCommand() //sends skeleton to farm on a free farming spots, if any
    {
        Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];
        FarmingSpot farmingSpot = GetClosestFarmingSpotToSkeleton(skeleton);

        farmingSpot.CallSkeleton(skeleton);

        //skeleton.farmingSpot = farmingSpot;
        //skeleton.doingTask = true;
        //skeleton.MoveTo(farmingSpot.transform.position);
        ////skeleton.ChangeState(skeleton.myStats.farmingState);
        //UnitSelection.Instance.Deselect(skeleton);
        //farmingSpot.Ocupar();
    }

    FarmingSpot GetClosestFarmingSpotToSkeleton(Skeleton skeleton)
    {
        FarmingSpot closestFarmingSpot = null;
        float closestDistance = Mathf.Infinity;

        foreach (FarmingSpot FS in ControlaListas.instance.farmingSpotList)
        {
            float distance = Vector3.Distance(skeleton.transform.position, FS.transform.position);
            if (distance < closestDistance)
            {
                closestFarmingSpot = FS;
                closestDistance = distance;
            }
        }

        return closestFarmingSpot;
    }

    public void LiberarEsqueleto()
    {
        trabalhandoAqui[0].transform.position = saida.position;
        trabalhandoAqui[0].ResetSkeleton();
        workingHere--;
        trabalhandoAqui.RemoveAt(0);
        myInterface.Atualiza();
    }

    public void SaveData(ref SceneData data)
    {
        data.grinders.Add(new GrinderAdapter(this));
    }
}
