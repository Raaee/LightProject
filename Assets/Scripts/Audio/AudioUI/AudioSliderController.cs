using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TextMeshProUGUI sfxText;
    [SerializeField] private TextMeshProUGUI musicText;
    private FMOD.Studio.VCA musicVCA;
    private FMOD.Studio.VCA sfxVCA;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicVolChange);
        sfxSlider.onValueChanged.AddListener(OnSfxVolChange);
        TryLoadAudioData();
    }

    private void TryLoadAudioData()
    {
        //TODO: add the vca stuff too
        int musicVolLoaded = (int)(ES3.Load(Utility.MUSIC_VOLUME_KEY , 0.75f) * 100);
        musicText.text = musicVolLoaded.ToString();
        musicSlider.value = ES3.Load(Utility.MUSIC_VOLUME_KEY, 0.75f);
        
        int sfxVolLoaded = (int)(ES3.Load(Utility.SFX_VOLUME_KEY , 0.75f) * 100);
        sfxText.text = sfxVolLoaded.ToString();
        sfxSlider.value = ES3.Load(Utility.SFX_VOLUME_KEY, 0.75f);
    }

    private void OnMusicVolChange(float newVolume)
    {

        musicText.text = ((int)(newVolume*100)).ToString();
       // musicVCA.setVolume(newVolume);
        ES3.Save(Utility.MUSIC_VOLUME_KEY, newVolume);
    }

    private void OnSfxVolChange(float newVolume)
    {
       
        sfxText.text = ((int)(newVolume * 100)).ToString();
        //sfxVCA.setVolume(newVolume);
        ES3.Save(Utility.SFX_VOLUME_KEY, newVolume);
    }
}
