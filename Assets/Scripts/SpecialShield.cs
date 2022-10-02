using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShield : MonoBehaviour
{
    private bool hasCollide = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth player = collision.GetComponent<playerHealth>();
        GameObject obj = GameObject.FindWithTag("Bullet");
        if (obj != null && gameObject.GetComponent<Collider2D>().IsTouching(obj.GetComponent<Collider2D>()))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
        }
        if (player != null && hasCollide == false)
        {
            hasCollide = true;
            player.SetInvincible();
            Destroy(gameObject);
            
        }
    }
}
