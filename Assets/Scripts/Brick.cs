using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.BrickTouch();
            UIManager.Instance.ViewLeft();
        }
    }
}
