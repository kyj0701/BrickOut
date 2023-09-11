using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Speed = Time.deltaTime * ballSpeed;
        transform.Translate(new Vector3(0, Speed, 0f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 temp = transform.eulerAngles;
        if (collision.gameObject.CompareTag("TopWall"))//위 쪽 벽
        {
            temp.z = 180f - temp.z;
            transform.eulerAngles = temp;
        }
        else if (collision.gameObject.CompareTag("Wall"))//양 옆 벽
        {
            temp.z = (180f * 2) - temp.z;
            transform.eulerAngles = temp;
        }

    }


   

}
