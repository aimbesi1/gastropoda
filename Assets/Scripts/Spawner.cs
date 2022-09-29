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
    public Transform pt4;
    public Transform pt5;
    public Transform pt6;
    public Transform pt7;
    public Transform pt8;
    public Transform pt9;
    public Transform pt10;
    public Transform pt11;
    public Transform pt12;
    public Transform pt13;
    public Transform pt14;
    public Transform pt15;

    List<Transform> pts = new List<Transform>();

    public GunSpawn gun ;
    public ClipSpawn clip;
    public HeartSpawn heart;
    public ShieldSpawn shield;
    public SwordSpawn sword;

    void Start()
    {
        addPoint(pt1);
        addPoint(pt2);
        addPoint(pt3);
        addPoint(pt4);
        addPoint(pt5);
        addPoint(pt6);
        addPoint(pt7);
        addPoint(pt8);
        addPoint(pt9);
        addPoint(pt10);
        addPoint(pt11);
        addPoint(pt12);
        addPoint(pt13);
        addPoint(pt14);
        addPoint(pt15);
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
        if (rand1 == 1)
        {
            Instantiate(shield, pts[rand2].position, pts[rand2].rotation);
        }
        else if (rand1 == 2)
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

    void addPoint(Transform pt)
    {
        if(pt != null)
        {
            pts.Add(pt);
        }
    }


}
