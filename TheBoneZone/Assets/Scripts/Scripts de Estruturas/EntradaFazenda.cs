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
            estaFazenda.trabalhandoAqui.Add(other.gameObject);
            other.transform.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.position = GameManager.instance.deposit.transform.position;
            UnitSelection.Instance.Deselect(other.gameObject.GetComponent<Skeleton>());
            estaFazenda.quantidadeEsqueletos++;
            estaFazenda.myInterface.Atualiza();
        }
    }
}
