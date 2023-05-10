using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyBase : MonoBehaviour
{
    public static MyBase instance;

    public MapNode baseNode;
    public Material baseMaterial;

    public GameObject invadingInterface;

    public NotConqueredNode targetNode;

    public TextMeshProUGUI goldRewardText;

    public int skeletonAmount;
    public TextMeshProUGUI skeletonAmountText;
    public int skeletonCost;
    public TextMeshProUGUI costText;

    private void Start()
    {
        instance = this;
        //GameObject baseNodeObj = baseNode.transform.GetChild(0).gameObject;
        //baseNodeObj.GetComponent<MeshRenderer>().material = baseMaterial;
    }

    public void AddTroop()
    {
        skeletonCost += 1000;
        skeletonAmount++;

        if (GameManager.instance.resourceManager.calcium < skeletonCost)
        {
            skeletonCost -= 1000;
            skeletonAmount -= 1;
        }
        costText.text = "Custo: " + skeletonCost.ToString();
        skeletonAmountText.text = skeletonAmount.ToString();
    }
    public void RemoveTroop()
    {
        skeletonCost -= 1000;
        skeletonAmount--;

        if (skeletonAmount < 0)
        {
            skeletonCost = 0;
            skeletonAmount = 0;
        }
        costText.text = "Custo: " + skeletonCost.ToString();
        skeletonAmountText.text = skeletonAmount.ToString();
    }

    public void ResetTroops()
    {
        skeletonCost = 0;
        skeletonAmount = 0;
    
        costText.text = "Custo: " + skeletonCost.ToString();
        skeletonAmountText.text = skeletonAmount.ToString();
    }

    public void initiateBattle()
    {
        if (skeletonAmount <= 0) return;

        targetNode.numberOfAllies = skeletonAmount;
        GameManager.instance.UpdateCalcium(-MyBase.instance.skeletonCost);
        targetNode.Battle();
    }

}
