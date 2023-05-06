using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Bares : MonoBehaviour
{
    public TextMeshProUGUI slots;
    List<Skeleton> descansandoAqui = new List<Skeleton>();
    public Transform entrada, saida;
    public int limiteEsqueletos = 5;

    [SerializeField]
    StructureFlyweight myStats;

    public float multiplier = 5;
    void Awake()
    {
        ControlaListas.instance.pubsLivres.Add(this);
        GameManager.instance.maxSkeletons += limiteEsqueletos;
        GameManager.instance.UpdateSkeletonCount();
    }

    void OnMouseOver()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;
        if (Input.GetMouseButtonDown(1))
        {
            ChamarEsqueletos();
        }
    }

    void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;


        if (descansandoAqui.Count < myStats.grinderSkeletonLimit)
        {
            SendSkeletonToPub();

            ChamarEsqueletos();
        }

    }

    void SendSkeletonToPub()
    {
        Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];

        skeleton.MoveTo(entrada.position);
        skeleton.pubTarget = this;
        skeleton.doingTask = true;
        skeleton.ChangeState(skeleton.myStats.restingState);
        UnitSelection.Instance.Deselect(skeleton);
        descansandoAqui.Add(skeleton);
    }


    void AtualizaInterface()
    {
        slots.text = "" + descansandoAqui.Count + "/" + limiteEsqueletos;
    }

    public void LiberaEsqueleto(Skeleton esqueleto)
    {
        descansandoAqui[0].transform.position = saida.position;
        descansandoAqui[0].ResetSkeleton();
        descansandoAqui.RemoveAt(0);
    }

}
