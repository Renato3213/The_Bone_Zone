using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moedas = 10;
    void Awake()
    {
        GameManager.instance.enemies.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemies.Remove(this.gameObject);
    }
}
