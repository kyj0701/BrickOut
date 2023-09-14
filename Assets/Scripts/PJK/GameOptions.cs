using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOptions : MonoBehaviour
{
    public GameObject optionBtn;
    public GameObject optionMenu;

    public GameObject ball;

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
        Time.timeScale = 1.0f;

        if (ball != null) ball.SetActive(false);
        MySceneManager.Instance.ChangeScene("Stage" + GameManager.Instance.StageLevel);
    }

    public void ToStage(int stageLevel)
    {
        Time.timeScale = 1.0f;

        if (ball != null) ball.SetActive(false);
        GameManager.Instance.StageLevel = stageLevel;

        MySceneManager.Instance.ChangeScene("Stage" + stageLevel);

        //SceneManager.LoadScene("StageScene");
    }

    public void ToStageSelect()
    {
        Time.timeScale = 1.0f;

        if (ball != null) ball.SetActive(false);
        GameManager.Instance.StageLevel = 0;

        MySceneManager.Instance.ChangeScene("Stage0");

        //SceneManager.LoadScene("StageScene");
    }

    public void ToMain()
    {
        Time.timeScale = 1.0f;

        if (ball != null) ball.SetActive(false);
        GameManager.Instance.StageLevel = -1;

        MySceneManager.Instance.ChangeScene("StartScene");

        //SceneManager.LoadScene("StartScene");
    }
}
