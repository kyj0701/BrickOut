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
            for (float i = -1.12f; i > -2.1f; i -= 0.32f)
            {
                GameObject brick = Instantiate(brickPrefab, new Vector3(i, j, 0), Quaternion.identity);
                brick.transform.SetParent(brickPool.transform);
            }

            for (float i = -0.48f; i < 0.5f; i += 0.32f)
            {
                GameObject brick = Instantiate(brickPrefab, new Vector3(i, j, 0), Quaternion.identity);
                brick.transform.SetParent(brickPool.transform);
            }

            for (float i = 1.12f; i < 2.1f; i += 0.32f)
            {
                GameObject brick = Instantiate(brickPrefab, new Vector3(i, j, 0), Quaternion.identity);
                brick.transform.SetParent(brickPool.transform);
            }
        }
    }
}
