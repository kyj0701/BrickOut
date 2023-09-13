using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public string SceneName;
    public GameObject option;
    public GameObject button;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SceneChange(int stageLevel)
    {
        //Invoke("changing",0.5f);
        GameManager.Instance.StageLevel = stageLevel;
        MySceneManager.Instance.ChangeScene("Stage" + stageLevel);
        //Invoke("changing", 5f);
    }

    public void newGame()
    {        
        SceneManager.LoadScene("StartScene");
    }

    public void changing()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void close()
    {
        option.SetActive(false);
        button.SetActive(true);
    }
}
