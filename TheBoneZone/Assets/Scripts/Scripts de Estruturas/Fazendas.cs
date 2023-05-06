using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendas : MonoBehaviour
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
    public List<Skeleton> trabalhandoAqui = new List<Skeleton>();

    void Awake()
    {
        GameManager.instance.ListManager.grindersList.Add(this);
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
    }

    public void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;


        if(trabalhandoAqui.Count < myStats.grinderSkeletonLimit)
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
        skeleton.grinderTarget = this;
        skeleton.doingTask = true;
        skeleton.ChangeState(skeleton.myStats.grindingState);
        UnitSelection.Instance.Deselect(skeleton);
        trabalhandoAqui.Add(skeleton);
    }

    public void FarmCommand() //sends skeleton to farm on a free farming spots, if any
    {
        Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];
        FarmingSpot farmingSpot = ControlaListas.instance.farmingSpotList[0];

        skeleton.farmingSpot = farmingSpot;
        skeleton.doingTask = true;
        skeleton.MoveTo(farmingSpot.transform.position);
        skeleton.ChangeState(skeleton.myStats.farmingState);
        UnitSelection.Instance.Deselect(skeleton);
        farmingSpot.Ocupar();
    }

    public void LiberarEsqueleto()
    {
        trabalhandoAqui[0].transform.position = saida.position;
        trabalhandoAqui[0].ResetSkeleton();
        trabalhandoAqui.RemoveAt(0);
        myInterface.Atualiza();
    }

}
