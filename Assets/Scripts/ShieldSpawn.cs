using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    private int amount = 50;
    private float time = 6f;

    private bool hasCollide = false;

    void Update()
    {
        Destroy(gameObject, time);

    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        GameObject obj = GameObject.FindWithTag("Bullet");
        if(obj != null && gameObject.GetComponent<Collider2D>().IsTouching(obj.GetComponent<Collider2D>()))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
        }
        if(player != null && !hasCollide)
        {
            hasCollide = !hasCollide;
            Destroy(gameObject);
            player.Shield(amount);
        }
    }

}
