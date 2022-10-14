using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawn : MonoBehaviour
{
    [SerializeField] bool independent = false; // If true, this spawner will not reference any random weapon spawner.
    [SerializeField] bool permanent = false; // If true, this object will not despawn.

    private bool usable = false;

    private float time = 2f;

    private Spawner spawn;

    void Start()
    {
        if (!independent)
            spawn = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
    }

    void Update()
    {
        if(time > 0 && !permanent)
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
        if(player != null && !usable)
        {
            usable = !usable;
            Destroy(gameObject);
            player.getSword();
            if (!independent && spawn != null)
                spawn.sword_limit--;
        }
    }
}
