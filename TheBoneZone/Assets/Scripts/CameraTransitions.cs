using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitions : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer transition;
    [SerializeField]
    float transitionTime;
    [SerializeField]
    float fadeSpeed;
    [SerializeField]
    float refreshRate;

    private void Start()
    {
      
    }

    public void OnBlackOut()
    {
        StartCoroutine(BlackOut());
    }

    IEnumerator BlackOut()
    {
        yield return new WaitForSeconds(1f);
        float alphaColor = 0f;
        while(alphaColor < 1)
        {
            alphaColor += fadeSpeed;
            transition.color = new Color(transition.color.r, transition.color.g, transition.color.b, alphaColor);
            yield return new WaitForSeconds(refreshRate);
        }
        yield return new WaitForSeconds(0.2f);

        OnSlide();
    }

    public void OnSlide()
    {
        transition.transform.DOMoveX(-6, transitionTime * 2).SetEase(Ease.InExpo);
    }
}
