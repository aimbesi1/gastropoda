using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaltShakerGun : MonoBehaviour
{
    private int num_bullet = 10;
    public Transform firepoint;
    public GameObject Bullet;
    private int bulletVel1 = 500;
    private int bulletVel2 = 700;

    private PowerUpSpawner spawner;
    public Weapons weapons;
    private GameObject player;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        num_bullet = PlayerPrefs.GetInt("Shoottime");
        printText();
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && num_bullet > 0) // Type 1 shoot if pressed right mouse
        {
            shoot1();
            num_bullet--;
            PlayerPrefs.SetInt("Shoottime", num_bullet);
        }
        else if (Input.GetButtonDown("Fire2") && num_bullet > 0) // Type 2 shoot if pressed left mouse
        {
            shoot2();
            num_bullet--;
            PlayerPrefs.SetInt("Shoottime", num_bullet);
        }
        if (num_bullet <= 0) // Destroy the gun when out of shoot time
        {
            weapons.DestroySaltGun();
            if (spawner != null)
                spawner.saltgun_limit++;
        }
        printText();
        SetParent(player.transform);
    }

    void shoot1() // Slow shoot but wide spread
    {
        for (int i = 0; i <= 4; i++)
        {
            GameObject b = Instantiate(Bullet, firepoint.position, firepoint.rotation);

            switch (i)
            {
                case 0:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, -50f, 0));
                    break;
                case 1:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, -25f, 0));
                    break;
                case 2:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, 0f, 0));
                    break;
                case 3:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, 25f, 0));
                    break;
                case 4:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, 50f, 0));
                    break;


            }
        }
    }

    void shoot2() // Fast shoot but narrow spread
    {
        for (int i = 0; i <= 2; i++)
        {
            GameObject b = Instantiate(Bullet, firepoint.position, firepoint.rotation);

            switch (i)
            {
                case 0:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel2 + new Vector3(0, -10f, 0));
                    break;
                case 1:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel2 + new Vector3(0, 0, 0));
                    break;
                case 2:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel2 + new Vector3(0, 10f, 0));
                    break;

            }
        }
    }

    void printText()
    {
        text.text = "Shoot time: " + num_bullet;
    }

    void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
    }
}
