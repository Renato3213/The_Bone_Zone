using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitialStats : MonoBehaviour 
{
    public int enemniesHere;
    public int goldReward;

    public SpellsTree spellToUnlock;
    public TechTree upgradeToUnlock;

    public bool Conquered = false;

    [SerializeField]
    GameObject spellSprite;
    [SerializeField]
    GameObject upgradeSprite;

    void Victory()
    {
        GameManager.instance.UpdateGold(goldReward);
        //MyBase.instance.skeletonAmount = 0;
        //MyBase.instance.ResetTroops();
        //Destroy(battleState);
        Conquered = true;
        //unlock spells, if any
        //unlock upgrades, if any
        //do animations

        Debug.Log("Victory");
        
    }
}
