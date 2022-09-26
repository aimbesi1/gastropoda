using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawn : MonoBehaviour
{
    private bool hasCollide = false;

    private float time = 2f;

    private Spawner spawn;

    void Start()
    {
        spawn = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
    }

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
        Weapons player = hitInfo.GetComponent<Weapons>();
        if(player != null && !hasCollide)
        {
            hasCollide = !hasCollide;
            Destroy(gameObject);
            player.getSword();
            spawn.sword_limit--;
        }
    }
}
