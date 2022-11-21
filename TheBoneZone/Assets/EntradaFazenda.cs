using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaFazenda : MonoBehaviour
{
    public Fazendas estaFazenda;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Esqueleto"))
        {
            estaFazenda.trabalhandoAqui.Add(other.gameObject);
            other.transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
