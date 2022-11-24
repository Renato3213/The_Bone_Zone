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

    public List<GameObject> trabalhandoAqui = new List<GameObject> ();

    [SerializeField]
    InterfaceFazenda myInterface;
    void Awake()
    {
        ControlaListas.instance.listaFazendas.Add(this.gameObject);
        myInterface.Atualiza();
    }

    
    void FixedUpdate()
    {
        if(trabalhandoAqui.Count > 0)
        {
            tempo += Time.fixedDeltaTime;
            if(tempo > 1f)
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

    }

    private void OnMouseExit()
    {
        GameManager.instance.mouseOverObject = false;
    }
    public void ChamarEsqueletos()
    {
        if (UnitSelection.Instance.unitsSelected.Count == 0) return;

        int i = 0;
        while(i < UnitSelection.Instance.unitsSelected.Count || i < limiteEsqueletos)
        {
            UnitSelection.Instance.unitsSelected[i].transform.GetComponent<NavMeshAgent>().destination = entrada.position;
            i++;
            quantidadeEsqueletos++;
            myInterface.Atualiza();
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

}
