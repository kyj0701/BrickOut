using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Dictionary<string, Sprite> SpriteDic = new Dictionary<string, Sprite>();
    public Sprite sp;
    //======================================================================//
    //UI
    public TextMeshProUGUI leftText;
    //======================================================================//
    //▽ 시스템 및 프로퍼티 함수 ▽
    #region
    //생성된 벽돌 갯수
    //public int brickCreate;
    ////부순 벽돌 갯수 (Need Count)
    //private int brickDestroy;
    //public int BrickDestroy
    //{
    //    get
    //    {
    //        return brickDestroy;
    //    }

    //    set
    //    {
    //        BrickLeft--;
    //        if (brickCreate == BrickDestroy)
    //        {
    //            GameOver();
    //        }
    //        brickDestroy = value;
    //    }
    //}
    //// 남은 벽돌 갯수 (남은 = 생성 - 부순)
    //private int brickLeft;
    //public int BrickLeft
    //{
    //    get
    //    {
    //        //Debug.Log("C : " + brickCreate + "/ D : " + BrickDestroy);
    //        return brickCreate - brickDestroy;
    //    }

    //    set 
    //    {
    //        brickLeft = brickCreate - brickDestroy;

    //        if (brickLeft == 0) GameClear();
    //    }
    //}

    //활동중인 공 갯수 (0이 되면 게임 오버)

    private int brick;
    public int Brick
    {
        get
        {
            return brick;
        }
        set
        {
            brick = value;
        }
    }

    private int ballCount;
    public int BallCount
    {
        get
        {
            return ballCount;
        }

        set
        {
            if (ballCount < 1) GameOver();

            ballCount = value;
        }
    }

    private int stageLevel = -1;
    public int StageLevel
    {
        get
        {
            return stageLevel;
        }

        set
        {
            stageLevel = value;
        }
    }
    #endregion


    //======================================================================//
    //벽돌이 삭제될때 사용되는 함수

    //public void ViewLeft()
    //{
    //    leftText.text = "" + BrickLeft;
    //}
    
    public void BrickTouch()
    {
        brick--;

        if (brick == 0) GameClear();
    }

    public void GameClear()
    {
        Debug.Log("Game Clear!");

        Time.timeScale = 0;
        UIManager.Instance.optionBtn.SetActive(false);
        UIManager.Instance.gameOverWindow.SetActive(true);
        UIManager.Instance.gameOverText.text = "STAGE CLEAR";
        UIManager.Instance.gameOverText.color = Color.green;
    }

    public void GameOver()
    {
        //GameOver
        Time.timeScale = 0;
        UIManager.Instance.optionBtn.SetActive(false);
        UIManager.Instance.gameOverWindow.SetActive(true);
        UIManager.Instance.gameOverText.text = "GAME OVER";
        UIManager.Instance.gameOverText.color = Color.red;
    }

    public override void Awake()
    {
        base.Awake();
    }

    // 새로운 씬을 추가
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 새로운 씬에 아래 내용을 새로 호출
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (Time.timeScale != 1.0f) Time.timeScale = 1.0f;

        if (stageLevel > 0)
        {
            StageInit();
            UIManager.Instance.ViewLeft();
        }
    }

    // 게임 종료 시
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SpriteLoad(GameObject obj , string name)
    {
        obj.GetComponent<SpriteRenderer>().sprite = SpriteDic[name];

    }

    public void SpriteInit()
    {
        string path = "Assets/Resources/Sprites";
        DirectoryInfo di = new DirectoryInfo(path);
        foreach (FileInfo file in di.GetFiles())
        {
            if (!file.Name.Contains(".meta"))
            {
                string[] fileName = file.Name.Split('.');
                Sprite s = Resources.Load<Sprite>("Sprites/" + fileName[0]);
                SpriteDic.Add(fileName[0], s);
                //Debug.Log("파일명 : " + fileName[0]);

            }
        }
    }

    private void StageInit()
    {
        switch (stageLevel)
        {
            case 1:
                brick = 45;
                break;
            case 2:
                brick = 98;
                break;
            case 3:
                brick = 87;
                break;
            case 4:
                brick = 74;
                break;
            default:
                return;
        }
    }
}
