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

    GameObject skeletonBeingSpawned;
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

        skeletonBeingSpawned = MainBuilding.instance.skeletonFactory.CreateSkeleton();
        Skeleton skeletonClass = skeletonBeingSpawned.GetComponent<Skeleton>();
        while (percent < 1)
        {
            progress += Time.deltaTime;
            percent = progress / tweenTime;
            fill.fillAmount = Mathf.Lerp(0, 1, percent);
            yield return null;
        }
        MainBuilding.instance.skeletonFactory.ActivateSkeleton(skeletonBeingSpawned, skeletonClass);

        if(MainBuilding.instance.skeletonFactory.skeletonListContainer.transform.childCount <= 1)
        {
            MainBuilding.instance.skeletonFactory.skeletonList.SetActive(false);
        }


        Destroy(this.gameObject);

        yield break;
    }

    public void Cancelar(GameObject skeletonToCancel)
    {
        GameManager.instance.AtualizaCalcio(100);
        Destroy(skeletonBeingSpawned);
        Destroy(this.gameObject);
    }
}
