using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntradaFazenda : MonoBehaviour
{
    public Fazendas estaFazenda;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Esqueleto"))
        {
            if (!estaFazenda.Cheio())
            {
                estaFazenda.trabalhandoAqui.Add(other.gameObject);
                other.transform.GetComponent<NavMeshAgent>().isStopped= true;
                other.transform.GetComponent<NavMeshAgent>().enabled = false;
                other.transform.position = GameManager.instance.deposit.transform.position;
                UnitSelection.Instance.Deselect(other.gameObject);
                estaFazenda.quantidadeEsqueletos++;
                estaFazenda.myInterface.Atualiza();
            }
            else
            {
                ControlaListas.instance.fazendasLivres.Remove(estaFazenda);
                if(ControlaListas.instance.fazendasLivres.Count != 0)
                {
                    ControlaListas.instance.fazendasLivres[0].ChamarEsqueletos();
                }
            }
        }
    }
}
