using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNode : MonoBehaviour
{
    public LevelRefference levelReference;

    public GameObject conqueredVisual, notConqueredVisual;

    public string fase;

    public int difficultyLevel = 1;

    public int goldReward = 0;

    public SpellsTree spellToUnlock;

    public TechTree upgradeToUnlock;

    [SerializeField]
    bool Conquered;

    [SerializeField]
    GameObject spellSprite;
    [SerializeField]
    GameObject upgradeSprite;

    private void Awake()
    {
        if(levelReference.CurrentLevel == fase)
        {
            if (levelReference.isConquered)
            {
                Victory();
            }
        }
        
        if (spellToUnlock == null)
        {
            spellSprite.SetActive(false);
        }
        if (upgradeToUnlock == null)
        {
            upgradeSprite.SetActive(false);
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.UpdateActiveInterface(MyBase.instance.nodeInterface);
            MyBase.instance.targetNode = this;
            MyBase.instance.goldRewardText.text = goldReward.ToString();
            MyBase.instance.UpdateDifficultyStars(difficultyLevel);
        }
    }

    public void StartBattle()
    {
        GameManager.instance.GoToScene(fase);
    }


    public void Victory()
    {
        levelReference.isConquered = false;
        levelReference.CurrentLevel = null;
        GameManager.instance.UpdateGold(goldReward);
        

        Conquered = true;

        //unlock spells, if any
        //unlock upgrades, if any
        //do animations

        Debug.Log("Victory");

    }
}
