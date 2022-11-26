using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawn : MonoBehaviour
{
    private int health = 20;
    private float time = 2f;

    private bool hasCollide = false;

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if(player != null && !hasCollide)
        {
            hasCollide = !hasCollide;
            Destroy(gameObject);
            player.Heal(health);
        }
    }
}
