using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painel : MonoBehaviour
{
    public GameObject painel;

    public void DesativaInterface()
    {
        painel.SetActive(false);
        AbreInterfaces.instance.interfaces = 0;
    }
}
