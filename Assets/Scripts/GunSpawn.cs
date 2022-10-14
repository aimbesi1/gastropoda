using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour
{
    private bool hasCollide = false;

    private PowerUpSpawner spawn;
    private float time = 6f;

    void Start()
    {
        spawn = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    void Update()
    {
        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Weapons player = hitInfo.GetComponent<Weapons>();
        if(player != null && !hasCollide)
        {
            hasCollide = !hasCollide;
            Destroy(gameObject);
            player.getGun();
            spawn.gun_limit--;
        }

    }
}
