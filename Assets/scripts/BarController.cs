using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{

    Rigidbody rid;
    public float moveSpeed = 5.0f;
    public float minX = -3.197f;
    public float maxX = 3.197f;
    private float[] angles = { -60, -45, -30, -15, 0, 15, 30, 45, 60 };


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        Vector3 position = transform.position + movement;

        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.Translate(movement);
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 tmp = collision.transform.eulerAngles;
        if (collision.gameObject.tag == "Ball")
        {
            int randomAngle = Random.Range(0, angles.Length);
            tmp.z = angles[randomAngle];
            collision.transform.eulerAngles = tmp;


        }

    }
}


