using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{

    Rigidbody rid;
    public float moveSpeed = 5.0f;
    public float minX = -8.35f;
    public float maxX = 8.35f;
    private float[] angles = { -60, -45, 0, 45, 60 };
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
        Vector3 bar = collision.transform.eulerAngles;
        if (collision.gameObject.tag == "ball")
        {
            int randomAngle = Random.Range(0, angles.Length);
            bar.z = angles[randomAngle];
            collision.transform.eulerAngles = bar;
        }
    }

}
