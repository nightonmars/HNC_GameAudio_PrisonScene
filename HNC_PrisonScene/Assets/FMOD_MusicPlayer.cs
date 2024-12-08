using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FMOD_MusicPlayer : MonoBehaviour
{
    public EventReference musicEventReference;
    private string musicParamName;
    private EventInstance musicEventInstance;

    private void Start()
    {
        musicParamName = "MusicStages"; 
        PlayMusic();
        
    }

    void PlayMusic()
    {
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(musicEventReference);
        
        musicEventInstance.start();
    }

    public void StopMusic()
    {
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEventInstance.release();
    }

    public void doorOpenMusic()
    {
        musicEventInstance.setParameterByName(musicParamName, 1);
    }
    
    public void throughDoorOpenMusic()
    {
        musicEventInstance.setParameterByName(musicParamName, 2);
    }
    
}
