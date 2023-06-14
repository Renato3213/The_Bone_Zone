using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    
    public ResourceFlyweight resourceFlyweight;

    [SerializeField]
    TextMeshProUGUI calciumText;
    [SerializeField]
    TextMeshProUGUI goldText;
    [SerializeField]
    TextMeshProUGUI skeletonsText;

    int _goldToText;
    int _calciumToText;

    public float amountToPay;

    [SerializeField] 
    SkeletonFlyweight skeletonStats;

    void Start()
    {
        if(skeletonsText != null)
            InvokeRepeating("PaySkeletons", 10f, 10f);

        if(skeletonStats != null)
            UpdateSkeletonCount();

        UpdateCalcium(0);
        UpdateGold(0);
    }

    public void UpdateCalcium(float amount)
    {
        resourceFlyweight.calcium += amount;
        _calciumToText = (int)resourceFlyweight.calcium;
        calciumText.text = _calciumToText.ToString();
    }

    public void UpdateGold(float amount)
    {
        resourceFlyweight.gold += amount;
        _goldToText = (int)resourceFlyweight.gold;
        goldText.text = _goldToText.ToString();
    }

    public void UpdateSkeletonCount()
    {
        skeletonsText.text = UnitSelection.Instance.unitList.Count + "/" + GameManager.instance.maxSkeletons;
        if(UnitSelection.Instance.unitList.Count == 1) InvokeRepeating("PaySkeletons", 10f, 10f);
        if (UnitSelection.Instance.unitList.Count == 0) CancelInvoke("PaySkeletons");
    }

    public void PaySkeletons()
    {
        UpdateGold(-amountToPay);


        if (resourceFlyweight.gold > amountToPay)
        {
            skeletonStats.happinessCoefficient = 0.5f;
            foreach (Skeleton skeleton in UnitSelection.Instance.unitList)
            {
                skeleton.goldPocket += skeleton.myStats.minimumWage;
            }
        }
        else
        {
            skeletonStats.happinessCoefficient = 0.25f;
            foreach (Skeleton skeleton in UnitSelection.Instance.unitList)
            {
                skeleton.goldPocket += resourceFlyweight.gold / UnitSelection.Instance.unitList.Count;
            }
        } 
    }

}
