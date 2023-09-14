using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOptions : MonoBehaviour
{
    public GameObject optionBtn;
    public GameObject optionMenu;

    public void CloseMenu()
    {
        optionMenu.SetActive(false);
        optionBtn.SetActive(true);
    }

    public void CloseOption()
    {
        Time.timeScale = 1.0f;
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;

        if (SoundManager.Instance.volumeMixer == null)
        {
            SoundManager.Instance.volumeMixer = GameObject.FindGameObjectWithTag("BGMixer");
            SoundManager.Instance.volumeMixer.GetComponent<Slider>().value = SoundManager.Instance.AudioSource.volume;
            SoundManager.Instance.volumeMixer.GetComponent<Slider>().onValueChanged.AddListener(SoundManager.Instance.SetVolume);
        }
    }

    public void Retry()
    {
        MySceneManager.Instance.ChangeScene("Stage" + GameManager.Instance.StageLevel);

        Time.timeScale = 1.0f;
    }

    public void ToStage(int stageLevel)
    {
        MySceneManager.Instance.ChangeScene("Stage" + stageLevel);

        //SceneManager.LoadScene("StageScene");
    }

    public void ToStageSelect()
    {
        MySceneManager.Instance.ChangeScene("Stage0");

        //SceneManager.LoadScene("StageScene");
    }

    public void ToMain()
    {
        MySceneManager.Instance.ChangeScene("StartScene");

        //SceneManager.LoadScene("StartScene");
    }
}
