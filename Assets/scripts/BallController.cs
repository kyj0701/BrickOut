using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 4f;
    private bool isFrozen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isFrozen)
        {
            float Speed = Time.deltaTime * ballSpeed;
            transform.Translate(new Vector3(0, Speed, 0f));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 tmp = transform.eulerAngles;
        if (collision.gameObject.CompareTag("TopWall")) //À§ ÂÊ º®,ºí·Ï
        {
            tmp.z = 180f - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.gameObject.CompareTag("Wall")) //¾ç ¿· º®
        {
            tmp.z = (180f * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.gameObject.CompareTag("BottomWall")) //¹Ù´Ú
        {          
            isFrozen = true;
            Invoke("DestroyBall", 1f);

        }
    }

    void DestroyBall()
    {
        Destroy(gameObject);
    }

}
