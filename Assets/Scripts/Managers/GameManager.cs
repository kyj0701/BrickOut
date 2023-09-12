using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public Dictionary<string, Sprite> SpriteDic = new Dictionary<string, Sprite>();
    public Sprite sp;
    public GameObject g;
    public Transform t;
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
                //Debug.Log("ÆÄÀÏ¸í : " + fileName[0]);

            }
           
        }
    }
}
