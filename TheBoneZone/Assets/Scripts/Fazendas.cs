using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendas : MonoBehaviour
{
    public int quantidadeEsqueletos = 0;
    public int limiteEsqueletos = 5;
    public float producao = 20f;
    public float tempo = 0;

    public Transform entrada, saida;

    public List<GameObject> trabalhandoAqui = new List<GameObject>();

    public InterfaceFazenda myInterface;
    void Awake()
    {
        ControlaListas.instance.fazendasLivres.Add(this);
        myInterface.Atualiza();
    }


    void FixedUpdate()
    {
        if (trabalhandoAqui.Count > 0)
        {
            tempo += Time.fixedDeltaTime;
            if (tempo > 1f)
            {
                GameManager.instance.AtualizaCalcio(producao * quantidadeEsqueletos);
                tempo = 0;
            }
        }
    }

    private void OnMouseOver()
    {
        GameManager.instance.mouseOverObject = true;
        if (Input.GetMouseButtonDown(1))
        {
            ChamarEsqueletos();
        }
    }
    private void OnMouseDown()
    {
        GameManager.instance.UpdateActiveInterface(myInterface.gameObject);
    }

    private void OnMouseExit()
    {
        GameManager.instance.mouseOverObject = false;
    }
    public void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;
        int i = 0;
        foreach (var unit in UnitSelection.Instance.unitsSelected)
        {
            unit.transform.GetComponent<NavMeshAgent>().destination = entrada.position;
            UnitSelection.Instance.Deselect(unit.gameObject);
            i++;
            if (i == limiteEsqueletos) break;
        }
    }
    public void LiberarEsqueleto()
    {
        trabalhandoAqui[0].transform.position = saida.position;
        trabalhandoAqui[0].transform.GetChild(1).gameObject.SetActive(true);
        trabalhandoAqui.RemoveAt(0);
        quantidadeEsqueletos--;
        myInterface.Atualiza();
    }

    public bool Cheio()
    {
        if (trabalhandoAqui.Count == limiteEsqueletos)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
