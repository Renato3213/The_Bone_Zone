using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTile : MonoBehaviour
{
    public bool placeable;
    public MeshRenderer mRenderer;
    void Awake()
    {
        if (!placeable)
        {
            mRenderer.material = CombatManager.instance.notPlaceableMaterial;
        }
    }

  

    void AddToList()
    {
        while (!CombatManager.instance.tableTiles.Contains(this))
        {
            CombatManager.instance.tableTiles?.Add(this);
        }
    }


    public void TogglePlaceable()
    {
        placeable = !placeable;

        if (placeable)
        {
            mRenderer.material = CombatManager.instance.placeableMaterial;
        }
        else if (!placeable)
        {
            mRenderer.material = CombatManager.instance.notPlaceableMaterial;
        }
    }

}
