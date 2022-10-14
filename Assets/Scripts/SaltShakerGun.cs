using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltShakerGun : MonoBehaviour
{
    private int num_bullet = 10;
    public Transform firepoint;
    public GameObject Bullet;
    private int bulletVel = 100;

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
        for(int i = 0; i <= 2; i++)
        {
            GameObject b = Instantiate(Bullet, firepoint.position, firepoint.rotation);

            switch(i)
            {
                case 0:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel + new Vector3(0, -30f, 0));
                    break;
                case 1:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel + new Vector3(0, 0, 0));
                    break;
                case 2:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel + new Vector3(0, 30f, 0));
                    break;

            }
        }
    }
}
