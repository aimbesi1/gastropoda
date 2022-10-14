using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltBullet : MonoBehaviour
{
    private int dmg = 20;
    private float time = 3f;

    void Update()
    {
        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if(hitInfo.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if(snail != null)
        {
            snail.takeDamage(dmg);
            snail.Slow();
            Destroy(gameObject);
        }
    }
}
