using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    [Header("Slider REF")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private FMOD.Studio.VCA musicVCA;
    private FMOD.Studio.VCA sfxVCA;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicVolChange);
        sfxSlider.onValueChanged.AddListener(OnSfxVolChange);
    }

    public void OnMusicVolChange(float newVolume)
    {

        //musicText.text = ((int)(newVolume*100)).ToString();
       // musicVCA.setVolume(newVolume);
        ES3.Save(Utility.MUSIC_VOLUME_KEY, newVolume);
    }

    public void OnSfxVolChange(float newVolume)
    {
       
        //sfxText.text = ((int)(newVolume * 100)).ToString();
        //sfxVCA.setVolume(newVolume);
        ES3.Save(Utility.SFX_VOLUME_KEY, newVolume);
    }
}
