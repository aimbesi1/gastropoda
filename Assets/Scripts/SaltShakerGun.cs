using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltShakerGun : MonoBehaviour
{
    private int num_bullet = 10;
    public Transform firepoint;
    public GameObject Bullet;
    List<Transform> bullets;
    // Start is called before the first frame update
    void Awake()
    {
        bullets = new List<Transform>(num_bullet);
        for(int i = 0; i < num_bullet; i++)
        {
            bullets.Add(Quaternion.Euler(Vector2.zero));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        int i = 0;
        foreach(Quaternion quat in bullets)
        {
            
        }
    }
}
