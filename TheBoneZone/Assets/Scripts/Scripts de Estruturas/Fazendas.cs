using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendas : MonoBehaviour
{
    //public int quantidadeEsqueletos;
    public int limiteEsqueletos;
    public float producao;
    public float tempo;

    public float storageLimit;
    public float bonesStored;

    public Transform entrada, saida;

    public List<Skeleton> trabalhandoAqui = new List<Skeleton>();


    public InterfaceFazenda myInterface;
    void Awake()
    {
        GameManager.instance.listas.grindersList.Add(this);
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

    void FixedUpdate()
    {


        //if (trabalhandoAqui.Count > 0)
        //{
        //    tempo += Time.fixedDeltaTime;
        //    if (tempo > 1f)
        //    {
        //        GameManager.instance.AtualizaCalcio(producao * quantidadeEsqueletos);
        //        for (int i = 0; i < trabalhandoAqui.Count; i++)
        //        {
        //            Skeleton skeleton = trabalhandoAqui[i].GetComponent<Skeleton>();

        //            if (skeleton.energy <= 0 || skeleton.happiness <= 0)
        //            {
        //                skeleton.energy = skeleton.energy < 0 ? 0 : skeleton.energy;
        //                skeleton.happiness = skeleton.happiness < 0 ? 0 : skeleton.happiness;
        //                trabalhandoAqui[i].transform.position = saida.position;
        //                trabalhandoAqui[i].transform.GetComponent<NavMeshAgent>().enabled = true;
        //                //quantidadeEsqueletos--;
        //                myInterface.Atualiza();
        //                skeleton.Recover();
        //                trabalhandoAqui.Remove(trabalhandoAqui[i]);
        //            }
        //            else
        //            {
        //                skeleton.happiness -= 3;
        //                skeleton.energy -= 20;
        //            }
        //        }
        //        tempo = 0;
        //    }
        //}
    }

    public bool IsFull()
    {
        return trabalhandoAqui.Count >= limiteEsqueletos;
    }

    public void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;

        //int i = 0;
        //foreach (var unit in UnitSelection.Instance.unitsSelected)
        //{
        //    if (i == limiteEsqueletos) break;
        //    unit.transform.GetComponent<NavMeshAgent>().destination = entrada.position; 
        //    i++;

        //}

        if(trabalhandoAqui.Count < limiteEsqueletos)
        {
            Debug.Log("upe");
            Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];

            skeleton.MoveTo(entrada.position);
            skeleton.grinderTarget = this;
            skeleton.doingTask = true;
            skeleton.currentState = skeleton.grindingState;
            UnitSelection.Instance.Deselect(skeleton);
            trabalhandoAqui.Add(skeleton);
            ChamarEsqueletos();
        }
        else
        {
            if (ControlaListas.instance.farmingSpotList.Count == 0) return;

            Skeleton skeleton = UnitSelection.Instance.unitsSelected[0];
            FarmingSpot farmingSpot = ControlaListas.instance.farmingSpotList[0];

            skeleton.farmingSpot = farmingSpot;
            skeleton.doingTask = true;
            skeleton.MoveTo(farmingSpot.transform.position);
            skeleton.currentState = skeleton.farmingState;
            UnitSelection.Instance.Deselect(skeleton);
            farmingSpot.Ocupar();
            ChamarEsqueletos();
        }
    }
    public void LiberarEsqueleto()
    {
        trabalhandoAqui[0].transform.position = saida.position;
        trabalhandoAqui[0].transform.GetComponent<NavMeshAgent>().enabled = true;
        trabalhandoAqui.RemoveAt(0);
        //quantidadeEsqueletos--;
        myInterface.Atualiza();
    }

}
