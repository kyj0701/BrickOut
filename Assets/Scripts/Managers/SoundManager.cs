using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            return instance == null ? null : instance;
        }
    }

    private AudioSource audioSource;
    public AudioSource AudioSource
    {
        get
        {
            return audioSource == null ? null : audioSource;
        }
    }
    private GameObject[] musics;

    public GameObject volumeMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        musics = GameObject.FindGameObjectsWithTag("Music");
        if(musics.Length >= 2 )
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();

        volumeMixer.GetComponent<Slider>().onValueChanged.AddListener(SetVolume);
    }

    public void PlayMusic()
    {
        if(audioSource.isPlaying) {
            return;
        }
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}
