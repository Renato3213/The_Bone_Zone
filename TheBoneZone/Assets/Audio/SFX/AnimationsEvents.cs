using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    [SerializeField]
    AudioClip[] footsteps;

    [SerializeField]
    AudioSource audioSource;
    public void OnFootStep()
    {
        AudioClip randomFootStep = footsteps[Random.Range(0, footsteps.Length)];
        audioSource.clip = randomFootStep;

        audioSource.Play();
    }
}
