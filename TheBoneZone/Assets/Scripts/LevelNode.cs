using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelNodeData
{
    public string fase;
    public bool conquered;

    public LevelNodeData(string fase, bool conquered)
    {
        this.fase = fase;
        this.conquered = conquered;
    }
}

public class LevelNode : MonoBehaviour, IDataPersistance
{
    public LevelRefference levelReference;

    public GameObject conqueredVisual, notConqueredVisual;

    public string fase;

    public int difficultyLevel = 1;

    public int goldReward = 0;

    public SpellsTree spellToUnlock;

    public TechTree upgradeToUnlock;

    public bool Conquered;

    [SerializeField]
    GameObject spellSprite;
    [SerializeField]
    GameObject upgradeSprite;

    private void Awake()
    {
        ControlaListas.instance.levels.Add(this);

        if(PlayerPrefs.GetString("fase") == fase)
        {
            if (PlayerPrefs.GetInt("Conquered") == 1)
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
        PlayerPrefs.SetInt("Conquered", 0);
        PlayerPrefs.SetString("fase", this.fase);
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

    public void SaveData(ref SceneData data)
    {
        data.levelNodes.Add(new LevelNodeData(fase, Conquered));
    }
}
