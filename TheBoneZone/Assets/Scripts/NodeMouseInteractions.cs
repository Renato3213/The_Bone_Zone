using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMouseInteractions : MonoBehaviour
{
    [SerializeField]
    float duration;
    [SerializeField]
    float maxY, minY;
    private void OnMouseEnter()
    {
        transform.DOMoveY(maxY, duration).SetEase(Ease.OutBack);
    }

    private void OnMouseExit()
    {
        transform.DOMoveY(minY, duration).SetEase(Ease.OutBack);
    }

    private void OnMouseDown()
    {
        transform.DOPunchPosition(new Vector3(0,minY/3,0), duration).SetEase(Ease.OutBack);
    }
}
