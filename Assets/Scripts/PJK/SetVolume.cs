using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public Slider volumeMixer;
    public AudioSource musicsource;

    public void SetMusicVolume()
    {
        musicsource.volume = volumeMixer.value;
    }
}
