using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmFila : MonoBehaviour
{
    public Image fill;
    public float tweenTime;
    float progress;
    float percent;
    public void Awake()
    {
        tweenTime = 5.5f;
        StartCoroutine(Prepara());
        fill.fillAmount = 0;
        progress = 0;
        percent = progress / tweenTime;
    }
    public IEnumerator Prepara()
    {
        while(MainBuilding.instance.skeletonFactory.skeletonListContainer.transform.GetChild(0).gameObject != this.gameObject)
        {
            yield return null;
        }
        while (percent < 1)
        {
            progress += Time.deltaTime;
            percent = progress / tweenTime;
            fill.fillAmount = Mathf.Lerp(0, 1, percent);
            yield return null;
        }

        if(MainBuilding.instance.skeletonFactory.skeletonListContainer.transform.childCount <= 1)
        {
            MainBuilding.instance.skeletonFactory.skeletonList.SetActive(false);
        }

        MainBuilding.instance.skeletonFactory.ActivateSkeleton();

        Destroy(this.gameObject);

        yield break;
    }

    public void Cancelar()
    {
        GameManager.instance.AtualizaCalcio(100);
        MainBuilding.instance.skeletonFactory.CancelSpawn();
        Destroy(this.gameObject);
    }
}
