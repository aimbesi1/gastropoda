using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float time = 3f;
    public int rand;

    public GunSpawn gun ;
    public ClipSpawn clip;
    public HeartSpawn heart;
    public ShieldSpawn shield;

    void Start()
    {
        Instantiate(gun, transform.position, transform.rotation);
    }

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0)
        {
            Spawn();
            time = 3f;
        }
    }

    void Spawn()
    {
        rand = Random.Range(3, 4);
        if (rand == 1)
        {
            Instantiate(shield, transform.position, transform.rotation);
        }
        if(rand == 2)
        {
            Instantiate(heart, transform.position, transform.rotation);
        }
        if(rand == 3)
        {
            Instantiate(clip, transform.position, transform.rotation);
        }
    }


}
