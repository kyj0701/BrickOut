using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 4f;
    public AudioSource ballSource;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float Speed = Time.deltaTime * ballSpeed;
        transform.Translate(new Vector3(0, Speed, 0f));
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayMusic();
        Vector3 tmp = transform.eulerAngles;
        if (collision.gameObject.CompareTag("TopWall")) //�� �� ��,����
        {
            tmp.z = 180f - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.gameObject.CompareTag("Wall")) //�� �� ��
        {
            tmp.z = (180f * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.gameObject.CompareTag("BottomWall")) //�ٴ�
        {

            DestroyBall();
        }

    }

    void DestroyBall()
    {
        Destroy(gameObject);
        GameManager.Instance.GameOver();
    }

    public void PlayMusic()
    {        
        ballSource.Play();
    }
}
