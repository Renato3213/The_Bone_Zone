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
            Debug.Log("");
            estaFazenda.trabalhandoAqui.Add(other.gameObject);
            other.gameObject.SetActive(false);
            UnitSelection.Instance.Deselect(other.transform.parent.gameObject);
        }
    }
}
