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

        Portal portal = FindObjectOfType<Portal>();
        if (portal == null)
        {
            Debug.LogError("No portal in scene?");
            return;
        }
        portal.OnPlayerEntersPortal.AddListener(StopCurrentSong);

    }


    private void PlayRandomSong()
    {
     //we dont want to repeat the last played song but we also dont want to rely on a while loop
     //solution "remove" the last played song in the list and then randomly choose
        string INDEX_KEY = "Hi Rae";
        int lastRepeatedIndex = ES3.Load(INDEX_KEY,0);
        int rand = Utility.GetRandomIndexNonRepeat(lastRepeatedIndex, musicTracks.Count);
  
        extendedAudioContainers[rand].StartAudio();
        currentlyPlayingTrack = rand;
        DisplayPeteDebugMusicSystem(lastRepeatedIndex, rand);

        ES3.Save(INDEX_KEY, currentlyPlayingTrack);
    }
    private void DisplayPeteDebugMusicSystem(int lastRepeatedIndex, int chosenInd)
    {
        string text = "Hello! This is your DJ Debuggin-Pete.\n";
        text += "The last song played was " + musicTracks[lastRepeatedIndex].Path + "\n";
        text += "Coming right up is " + musicTracks[chosenInd].Path + ". So sit back and enjoy the tunes";
        Debug.Log(text);
    }

    public void StopCurrentSong()
    {
        //stop song on index
        extendedAudioContainers[currentlyPlayingTrack].StopAudio();
    }


}
