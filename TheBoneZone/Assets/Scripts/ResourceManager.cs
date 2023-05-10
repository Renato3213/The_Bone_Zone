using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public float calcium;
    public float gold;

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
        InvokeRepeating("PaySkeletons", 10f, 10f);
        UpdateCalcium(0);
        UpdateGold(0);
        UpdateSkeletonCount();
    }

    public void UpdateCalcium(float amount)
    {
        calcium += amount;
        _calciumToText = (int)calcium;
        calciumText.text = _calciumToText.ToString();
    }

    public void UpdateGold(float amount)
    {
        gold += amount;
        _goldToText = (int)gold;
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


        if (gold > amountToPay)
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
                skeleton.goldPocket += gold/ UnitSelection.Instance.unitList.Count;
            }
        } 
    }

}
