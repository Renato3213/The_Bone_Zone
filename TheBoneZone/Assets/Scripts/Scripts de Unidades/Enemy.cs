using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float vida;
    public float moedas;
    void Awake()
    {
        vida = 10 + (10 * (GameManager.instance.Infamia / 100));
        moedas = 10 + Mathf.Abs((10 * (GameManager.instance.Infamia / 100)));
        GameManager.instance.enemies.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.AtualizaCalcio(moedas);
        GameManager.instance.enemies.Remove(this.gameObject);
    }

    public void TakeDamage(float dano)
    {
        if(dano >= vida)
        {
            Destroy(this.gameObject);
        }
        else
        {
            vida -= dano;
        }
    }
}
