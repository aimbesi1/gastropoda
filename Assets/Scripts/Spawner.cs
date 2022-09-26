using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int gun_limit = 1;

    public int sword_limit = 1;

    public float time = 3f;
    public int rand1;
    public int rand2;

    public Transform pt1;
    public Transform pt2;
    public Transform pt3;

    List<Transform> pts = new List<Transform>();

    public GunSpawn gun ;
    public ClipSpawn clip;
    public HeartSpawn heart;
    public ShieldSpawn shield;
    public SwordSpawn sword;

    public playerHealth player;

    void Start()
    {
        addPoint();
        Spawn();
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
        rand1 = Random.Range(1, 6);
        rand2 = Random.Range(0, 3);
        if (rand1 == 1 && player.currentHealth != player.maxHealth)
        {
            Instantiate(shield, pts[rand2].position, pts[rand2].rotation);
        }
        else if (rand1 == 2 && player.currentShield != player.maxShield)
        {
            Instantiate(heart, pts[rand2].position, pts[rand2].rotation);
        }
        else if (rand1 == 3 && gun_limit <= 0)
        {
            Instantiate(clip, pts[rand2].position, pts[rand2].rotation);
        }
        else if (rand1 == 4 && gun_limit > 0)
        {
            Instantiate(gun, pts[rand2].position, pts[rand2].rotation);

        }
        else if (rand1 == 5 && sword_limit > 0)
        {
            Instantiate(sword, pts[rand2].position, pts[rand2].rotation);
        }
    }

    void addPoint()
    {
        pts.Add(pt1);
        pts.Add(pt2);
        pts.Add(pt3);
    }


}
