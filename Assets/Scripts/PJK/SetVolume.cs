using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioSource musicsource;
    
    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }
}
