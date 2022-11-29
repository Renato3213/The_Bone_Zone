using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mercado : MonoBehaviour
{
    public GameObject esqueleto;


    public void Compra()
    {
        if(GameManager.instance.Calcio >= 100)
        {
            GameObject teste = Instantiate(esqueleto, transform.position, transform.rotation);
            GameManager.instance.Calcio -= 100;
        }
    }
}
