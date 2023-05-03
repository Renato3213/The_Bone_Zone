using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingSpot : MonoBehaviour
{
    void Awake()
    {
        ControlaListas.instance.farmingSpotList.Add(this);
    }

    public void Ocupar()
    {
        ControlaListas.instance.farmingSpotList.Remove(this);
    }

    public void Desocupar()
    {
        ControlaListas.instance.farmingSpotList.Add(this);
    }

    void OnDestroy()
    {
        ControlaListas.instance.farmingSpotList.Remove(this);
    }
    
}
