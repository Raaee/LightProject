using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusicSysten : MonoBehaviour
{
    [Header("AUDIO")] 
    public List<EventReference> musicTracks;
    public List<ExtendedAudioContainer> extendedAudioContainers;

    private int currentlyPlayingTrack = 0;

    private void Start()
    {
        Init();
        PlayRandomSong();
    }
    void Init()
    {
        extendedAudioContainers = new List<ExtendedAudioContainer>();

        foreach (var musicTrack in musicTracks)
        {

            var instance = new ExtendedAudioContainer();
            instance.InitAudio(musicTrack);
            extendedAudioContainers.Add(instance);
        }
    }


    private void PlayRandomSong()
    {
        //pick random index 
        var rand = Random.Range(0, musicTracks.Count);
        //play song 
        extendedAudioContainers[rand].StartAudio();
        currentlyPlayingTrack = rand;
    }

    private void StopCurrentSong()
    {
        //stop song on index
        extendedAudioContainers[currentlyPlayingTrack].StopAudio();
    }


}
