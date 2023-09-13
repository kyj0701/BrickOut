using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<string, Sprite> SpriteLoad = new Dictionary<string, Sprite>();

    public override void Awake()
    {
        base.Awake();
        SpriteLoadInit();
    }

    public void SpriteLoadInit()
    {
        DirectoryInfo di = new DirectoryInfo("Assets/Resources/Images");
        foreach (FileInfo file in di.GetFiles())
        {
            if (!file.Name.Contains(".meta"))
            {
                string[] fileName = file.Name.Split('.');
    /*            Sprite sprite = new Sprite(file.);
                SpriteLoad.Add(fileName[0], file.);*/
                Debug.Log("ÆÄÀÏ¸í : " + file.Name);
            }          
        }
    }
}
