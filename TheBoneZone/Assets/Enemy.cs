using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    void Awake()
    {
        GameManager.instance.enemies.Add(this.gameObject);
    }

    
}
