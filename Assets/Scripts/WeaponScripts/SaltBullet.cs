using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltBullet : MonoBehaviour
{
    private int dmg = 10;

    private float fly_time = 2f;

    private RaycastHit2D raycast;
    public Transform rayposition;

    void Update()
    {
        int layermask = 1 << 8;
        layermask = ~layermask;
        raycast = Physics2D.Raycast(rayposition.position, transform.right, Mathf.Infinity, layermask);
        if (raycast.collider.CompareTag("SpawnObj"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindWithTag("SpawnObj").GetComponent<Collider2D>());
        }
        if (raycast.collider.name == "Lever")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Lever").GetComponent<Collider2D>());
        }
        Destroy(gameObject, fly_time);

    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        GameObject ground = GameObject.FindWithTag("Ground");
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if (ground != null)
        {
            Destroy(gameObject);
        }
        if (snail != null)
        {
            snail.takeDamage(dmg);
            snail.slow();
            Destroy(gameObject);
        }

    }
}
