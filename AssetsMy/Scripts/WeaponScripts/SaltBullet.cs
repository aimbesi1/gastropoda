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
        if (snail != null && PlayerPrefs.GetInt("IsBoss") == 1)
        {
            snail.takeDamage(dmg);
            snail.slow();
            Destroy(gameObject);
        }
    }
}
