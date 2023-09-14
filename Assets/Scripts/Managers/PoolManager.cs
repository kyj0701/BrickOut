using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject brickPrefab;
    public GameObject brickPool;

    void Start()
    {
        SetBrick();
    }

    public void SetBrick()
    {
        for (float j = 4; j >= 3; j--)
        {
            for (float i = -3.25f; i <= -1.75f; i += 0.5f)
            {
                GameObject brick = Instantiate(brickPrefab, new Vector3(i, j, 0), Quaternion.identity);
                GameManager.Instance.Brick++;
                brick.transform.SetParent(brickPool.transform);
            }

            for (float i = -0.75f; i <= 0.75f; i += 0.5f)
            {
                GameObject brick = Instantiate(brickPrefab, new Vector3(i, j, 0), Quaternion.identity);
                GameManager.Instance.Brick++;
                brick.transform.SetParent(brickPool.transform);
            }

            for (float i = 1.75f; i <= 3.25f; i += 0.5f)
            {
                GameObject brick = Instantiate(brickPrefab, new Vector3(i, j, 0), Quaternion.identity);
                GameManager.Instance.Brick++;
                brick.transform.SetParent(brickPool.transform);
            }
        }
        //GameManager.Instance.ViewLeft();
    }
}
