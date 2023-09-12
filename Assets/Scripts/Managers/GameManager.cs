using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
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
    public int brickCreate;
    //부순 벽돌 갯수 (Need Count)
    private int brickDestroy;
    public int BrickDestroy
    {
        get
        {
            return brickDestroy;
        }

        set
        {
            BrickLeft--;
            if (brickCreate == BrickDestroy)
            {
                GameOver();
            }
            brickDestroy = value;
        }
    }
    // 남은 벽돌 갯수 (남은 = 생성 - 부순)
    private int brickLeft;
    public int BrickLeft
    {
        get 
        {
            //Debug.Log("C : " + brickCreate + "/ D : " + BrickDestroy);
            return brickCreate - BrickDestroy;
        }

        set { ViewLeft(); brickLeft = value; }
    }

    //활동중인 공 갯수 (0이 되면 게임 오버)
    private int ballCount;
    public int BallCount
    {
        get 
        { 
            return ballCount; 
        }

        set
        {
            if (ballCount < 1)
            {
                GameOver();
            }
            ballCount = value;
        }
    }
    #endregion


    //======================================================================//
    //벽돌이 삭제될때 사용되는 함수

    public void ViewLeft()
    {
        leftText.text = "" + BrickLeft;
    }
    
    public void BrickTouch()
    {
        BrickDestroy++;
        Debug.Log("Touch");
    }

    public void GameOver()
    {
        //GameOver
        Time.timeScale = 0;
    }

    public override void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        SpriteInit();
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
}
