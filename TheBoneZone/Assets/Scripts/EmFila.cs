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
        tweenTime = 1;
        StartCoroutine(Prepara());
        fill.fillAmount = 0;
        progress = 0;
        percent = progress / tweenTime;
    }
    public IEnumerator Prepara()
    {
        while(MainBuilding.instance.skeletonListContainer.transform.GetChild(0).gameObject != this.gameObject)
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
        MainBuilding.instance.InstantiateSkeleton();
        Destroy(this.gameObject);
        if(MainBuilding.instance.skeletonListContainer.transform.childCount == 0)
        {
            MainBuilding.instance.skeletonList.SetActive(false);
        }
        yield break;
    }

    public void Cancelar()
    {
        Destroy(this.gameObject);
    }
}
