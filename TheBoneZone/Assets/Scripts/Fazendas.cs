using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendas : MonoBehaviour
{
    public int quantidadeEsqueletos;
    public int limiteEsqueletos;
    public float producao;
    public float tempo;

    public Transform entrada, saida;

    public List<GameObject> trabalhandoAqui = new List<GameObject>();


    public InterfaceFazenda myInterface;
    void Awake()
    {
        ControlaListas.instance.fazendasLivres.Add(this);
    }

    void OnMouseOver()
    {
        GameManager.instance.mouseOverObject = true;
        if (Input.GetMouseButtonDown(1))
        {
            ChamarEsqueletos();
        }
    }
    void OnMouseDown()
    {
        GameManager.instance.UpdateActiveInterface(myInterface.gameObject);
    }

    void OnMouseExit()
    {
        GameManager.instance.mouseOverObject = false;
    }
    void FixedUpdate()
    {
        if (trabalhandoAqui.Count > 0)
        {
            tempo += Time.fixedDeltaTime;
            if (tempo > 1f)
            {
                GameManager.instance.AtualizaCalcio(producao * quantidadeEsqueletos);
                for (int i = 0; i < trabalhandoAqui.Count; i++)
                {
                    Skeleton skeleton = trabalhandoAqui[i].GetComponent<Skeleton>();

                    if (skeleton.energy <= 0 || skeleton.happiness <= 0)
                    {
                        skeleton.energy = skeleton.energy < 0 ? 0 : skeleton.energy;
                        skeleton.happiness = skeleton.happiness < 0 ? 0 : skeleton.happiness;
                        trabalhandoAqui[i].transform.position = saida.position;
                        trabalhandoAqui[i].transform.GetComponent<NavMeshAgent>().enabled = true;
                        quantidadeEsqueletos--;
                        myInterface.Atualiza();
                        skeleton.Recover();
                        trabalhandoAqui.Remove(trabalhandoAqui[i]);
                    }
                    else
                    {
                        skeleton.happiness -= 3;
                        skeleton.energy -= 20;
                    }
                }
                tempo = 0;
            }
        }
    }

    public void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;

        int i = 0;
        foreach (var unit in UnitSelection.Instance.unitsSelected)
        {
            if (i == limiteEsqueletos) break;
            unit.transform.GetComponent<NavMeshAgent>().destination = entrada.position;
            i++;

        }
    }
    public void LiberarEsqueleto()
    {
        trabalhandoAqui[0].transform.position = saida.position;
        trabalhandoAqui[0].transform.GetComponent<NavMeshAgent>().enabled = true;
        trabalhandoAqui.RemoveAt(0);
        quantidadeEsqueletos--;
        myInterface.Atualiza();
    }

}
