using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided successfully");
            collision.gameObject.transform.SetParent(transform);
        }
        else
        {
            Debug.Log("Collided with " + collision.gameObject.name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
