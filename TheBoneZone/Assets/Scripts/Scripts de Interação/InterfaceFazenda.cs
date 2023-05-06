using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceFazenda : MonoBehaviour
{
    [SerializeField]
    Fazendas estaFazenda;
    [SerializeField]
    TextMeshProUGUI Slots;
    public void Atualiza()
    {
        Slots.text = estaFazenda.trabalhandoAqui.Count + "/" + estaFazenda.myStats.grinderSkeletonLimit;
    }
}
