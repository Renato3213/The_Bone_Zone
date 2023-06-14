using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyBase : MonoBehaviour
{
    public LevelRefference levelReference;
    
    public static MyBase instance;

    public GameObject nodeInterface;


    public List<LevelNode> nodes = new List<LevelNode>();
    public LevelNode targetNode;

    public TextMeshProUGUI goldRewardText;

    public GameObject[] difficultyStars;

    public string targetFase;

    private void Start()
    {
        instance= this;

    }

    public void StartBattle()
    {
        levelReference.CurrentLevel = targetNode.fase;
        GameManager.instance.GoToScene(targetNode.fase);
    }

    public void UpdateDifficultyStars(int difficultyLevel)
    {
        StopCoroutine(TweenStars(difficultyLevel));
        StartCoroutine(TweenStars(difficultyLevel));
    }

    IEnumerator TweenStars(int difficultyLevel)
    {
        foreach (GameObject star in difficultyStars)
        {
            star.SetActive(false);
            star.transform.DOKill();
            star.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        for (int i = 0; i < difficultyLevel; i++)
        {
            difficultyStars[i].SetActive(true);
            difficultyStars[i].transform.DOScale(new Vector3(1, 1, 1), 0.25f).SetEase(Ease.OutBack);
            yield return null;
        }
    }

    #region redacted
    //public int skeletonAmount;
    //public TextMeshProUGUI skeletonAmountText;
    //public int skeletonCost;
    //public TextMeshProUGUI costText;

    //private void Start()
    //{
    //    instance = this;
    //    //GameObject baseNodeObj = baseNode.transform.GetChild(0).gameObject;
    //    //baseNodeObj.GetComponent<MeshRenderer>().material = baseMaterial;
    //}

    //public void AddTroop()
    //{
    //    skeletonCost += 1000;
    //    skeletonAmount++;

    //    if (GameManager.instance.resourceManager.calcium < skeletonCost)
    //    {
    //        skeletonCost -= 1000;
    //        skeletonAmount -= 1;
    //    }
    //    costText.text = "Custo: " + skeletonCost.ToString();
    //    skeletonAmountText.text = skeletonAmount.ToString();
    //}
    //public void RemoveTroop()
    //{
    //    skeletonCost -= 1000;
    //    skeletonAmount--;

    //    if (skeletonAmount < 0)
    //    {
    //        skeletonCost = 0;
    //        skeletonAmount = 0;
    //    }
    //    costText.text = "Custo: " + skeletonCost.ToString();
    //    skeletonAmountText.text = skeletonAmount.ToString();
    //}

    //public void ResetTroops()
    //{
    //    skeletonCost = 0;
    //    skeletonAmount = 0;

    //    costText.text = "Custo: " + skeletonCost.ToString();
    //    skeletonAmountText.text = skeletonAmount.ToString();
    //}



    //public void initiateBattle()
    //{
    //    if (skeletonAmount <= 0) return;

    //    targetNode.numberOfAllies = skeletonAmount;
    //    GameManager.instance.UpdateCalcium(-MyBase.instance.skeletonCost);
    //    targetNode.Battle();
    //}

    #endregion


}
