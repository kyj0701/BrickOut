using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDetroy : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<DontDetroy>();
        if(obj.Length == 1) {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
