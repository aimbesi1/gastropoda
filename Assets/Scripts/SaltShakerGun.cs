using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaltShakerGun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bullet;
    public TMP_Text text;
    private int bulletVel = 100;
    private int shoot_time = 10;

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetButtonDown("Fire1") && shoot_time > 0)
        {
            shoot1();
            shoot_time--;
        }
        else if (Input.GetButtonDown("Fire2") && shoot_time > 0)
        {
            shoot2();
            shoot_time--;
        }

        if(shoot_time <= 0)
        {
            Destroy(gameObject);
        }
        printText();
    }

    void printText()
    {
        text.text = "Shoot time left: " + shoot_time;
    }

    void shoot1()
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

    void shoot2()
    {
        for(int i = 0; i <= 2; i++)
        {
            GameObject b = Instantiate(Bullet, firepoint.position, firepoint.rotation);

            switch(i)
            {
                case 0:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel * 5 + new Vector3(0, -10f, 0));
                    break;
                case 1:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel * 5 + new Vector3(0, 0, 0));
                    break;
                case 2:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel * 5 + new Vector3(0, 10f, 0));
                    break;

            }
        }
    }
}
