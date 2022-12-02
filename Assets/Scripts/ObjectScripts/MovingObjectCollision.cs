using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectCollision : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // If the "Enemy" tag doesn't exist, use the "Snail" tag instead
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Block")|| collision.gameObject.CompareTag("Ground"))
        {
            // Set this transform as the parent of the subject's transform's parent to avoid messing up the scale or motion values
            collision.transform.parent.parent = transform;
        }
        else
        {
            Debug.Log("Collided with " + collision.gameObject.name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground"))
        {
            collision.transform.parent.parent = null;
        }
    }
}
