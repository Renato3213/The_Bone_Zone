using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public static MixerController instance;
    public AudioMixer mixer;
    public Slider sldMusic;
    public Slider sldGlobal;
    public Slider sldFX;
    public GameObject panel;
    public GameObject btnPausa;
    bool showPanel = false;
    bool botaoAtivado = true;


    void Start()
    {
        instance = this;
        /*PlayerPrefs.GetFloat("ConfigVolGlobal", sldGlobal.value);
        PlayerPrefs.GetFloat("MusicVolume", sldMusic.value);
        PlayerPrefs.GetFloat("FxVolume", sldFX.value);
        PlayerPrefs.GetFloat("VolumeGlobal", sldGlobal.value);
        sldMusic.value = PlayerPrefs.GetFloat("MusicVolume", sldMusic.value);
        sldFX.value = PlayerPrefs.GetFloat("FxVolume", sldFX.value);
        sldGlobal.value = PlayerPrefs.GetFloat("VolumeGlobal", sldGlobal.value);*/
    }
    public void Update()
    {
        //BotaoPausa();
        if(Input.GetKeyDown("p"))
        {
            showPanel = !showPanel;
            panel.SetActive(showPanel);
            GameManager.instance.SetPause(showPanel);
        }
    }

    public void DesativaPausa()
    {
        //BotaoPausa();
        showPanel = !showPanel;
        panel.SetActive(showPanel);
        GameManager.instance.SetPause(showPanel);
    }

    /*public void BotaoPausa()
    {
        if(botaoAtivado == true)
        {
            botaoAtivado = false;
            btnPausa.SetActive(false);
        }
        else if(botaoAtivado == false)
        {
            botaoAtivado = true;
            btnPausa.SetActive(true);
        }
    }*/

    /*public void ChangeMusicVolume()
    {
        mixer.SetFloat("MusicVolume", (sldMusic.value));
        PlayerPrefs.SetFloat("MusicVolume", sldMusic.value);
        GameManager.instance.sliderMusic = sldMusic.value;
        GameManager.instance.SaveSettings();
    }
    public void ChangeFxVolume()
    {
        mixer.SetFloat("FxVolume", (sldFX.value));
        PlayerPrefs.SetFloat("FxVolume", sldFX.value);
        GameManager.instance.sliderFx = sldFX.value;
        GameManager.instance.SaveSettings();
    }
    public void ChangeGlobalVolume()
    {
        mixer.SetFloat("VolumeGlobal", (sldGlobal.value));
        PlayerPrefs.SetFloat("VolumeGlobal", sldGlobal.value);
        PlayerPrefs.SetFloat("ConfigVolGlobal", sldGlobal.value);
        GameManager.instance.sliderGlobal = sldGlobal.value;
        GameManager.instance.SaveSettings();
    }*/
}