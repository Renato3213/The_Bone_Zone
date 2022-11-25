using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float vida = 10;
    public int moedas = 10;
    void Awake()
    {
        GameManager.instance.enemies.Add(this.gameObject);
    }

    private void OnDestroy()
    {
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
