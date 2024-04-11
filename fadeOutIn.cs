using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class fadeOutIn : MonoBehaviour
{
    public AudioSource bgm_inside;
    public AudioSource bgm_outside;
    public float fadeTime = 7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void fadeIn()
    {

        StartCoroutine(fadeInCoroutine(fadeTime));
    }

    private IEnumerator fadeInCoroutine(float fadeTime)
    {
        bgm_outside.Play();
        bgm_outside.volume = 0;
        float targetVolume = bgm_inside.volume;
        float currentVolume = bgm_outside.volume;
        while (bgm_outside.volume < targetVolume)
        {
            bgm_outside.volume += Time.deltaTime * targetVolume / fadeTime;
            yield return null;
        }
        bgm_outside.volume = targetVolume;
    }
    public void fadeOut()
    {
        StartCoroutine(FadeOutCoroutine(fadeTime));
    }

    private IEnumerator FadeOutCoroutine(float fadeTime)
    {
        float currentVolume = bgm_inside.volume;
        while (bgm_inside.volume > 0)
        {
            bgm_inside.volume -= currentVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        bgm_inside.Stop();
        
    }

}
