using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotConqueredNode : MapNode
{
    public NodeStats myStats;
    public TextMeshProUGUI enemiesText;
    InitialStats initialStats;

    int numberOfEnemies;
    public int numberOfAllies;

    int enemyDice;
    int playerDice;

    public GameObject spellSprite;
    public GameObject upgradeSprite;
    public GameObject conqueredState;
    public GameObject battleState;

    private void Awake()
    {
        initialStats = GetComponent<InitialStats>();
        numberOfEnemies = initialStats.enemniesHere;
        enemiesText.text = numberOfEnemies.ToString();

        if(initialStats.spellToUnlock == null)
        {
            spellSprite.SetActive(false);
        }
        if(initialStats.upgradeToUnlock == null)
        {
            upgradeSprite.SetActive(false);
        }

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.UpdateActiveInterface(MyBase.instance.nodeInterface);
            //MyBase.instance.targetNode = this;
            MyBase.instance.goldRewardText.text = initialStats.goldReward.ToString();
        }
    }

    //public void Battle()
    //{
    //    while(numberOfAllies > 0 && numberOfEnemies > 0)
    //    {
    //        enemyDice = Random.Range(1, 7);
    //        playerDice= Random.Range(1, 7);

    //        if (playerDice > enemyDice)
    //        {
    //            numberOfEnemies--;
    //        }

    //        else
    //        {
    //            numberOfAllies--;
    //        }
    //    }

    //    if(numberOfAllies > numberOfEnemies)
    //    {
    //        Victory();
    //    }

    //    else
    //    {
    //        Defeat();
    //    }
    //}

    //void Defeat()
    //{
    //    ////do animations
    //    //MyBase.instance.skeletonAmount = 0;
    //    //MyBase.instance.ResetTroops();
    //    //Debug.Log("Defeat");
    //}

    void Victory()
    {
        GameManager.instance.UpdateGold(initialStats.goldReward);
        //MyBase.instance.skeletonAmount = 0;
        //MyBase.instance.ResetTroops();
        Destroy(battleState);
        conqueredState.SetActive(true);
        //unlock spells, if any
        //unlock upgrades, if any
        //do animations

        Debug.Log("Victory");

        gameObject.AddComponent<ConqueredNode>();
        Destroy(this);
    }
}
