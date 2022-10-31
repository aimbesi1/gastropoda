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

    /*private int ammo;
    private int clip;

    private float reload_timer = 2f;
    private bool is_reload = false;*/

    // Start is called before the first frame update
    void Start()
    {
        /*ammo = num_bullet;
        clip = 2;*/
        printText();
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && num_bullet > 0)
        {
            shoot1();
            num_bullet--;
        }
        else if (Input.GetButtonDown("Fire2") && num_bullet > 0)
        {
            shoot2();
            num_bullet--;
        }
        if (num_bullet <= 0)
        {
            gameObject.SetActive(false);
            weapons.has_saltgun = false;
            if (spawner != null)
                spawner.saltgun_limit++;
        }
        printText();
        SetParent(player.transform);
    }

    void shoot1()
    {
        for (int i = 0; i <= 2; i++)
        {
            GameObject b = Instantiate(Bullet, firepoint.position, firepoint.rotation);

            switch (i)
            {
                case 0:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, -30f, 0));
                    break;
                case 1:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, 0, 0));
                    break;
                case 2:
                    b.GetComponent<Rigidbody2D>().AddForce(firepoint.right * bulletVel1 + new Vector3(0, 30f, 0));
                    break;

            }
        }
    }

    void shoot2()
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
    /*void reload()
    {
        clip--;
        ammo = num_bullet;
    }
    public void addClip()
    {
        clip++;
    }
    void printText()
    {
        if (is_reload)
        {
            text.text = "Reloading... " + Mathf.RoundToInt(reload_timer) + "s";
        }
        else if (!is_reload && ammo > 0)
        {
            text.text = ammo + "/" + num_bullet + " --- Clip: " + clip;
        }
        else if (ammo <= 0)
        {
            text.text = "OUT OF AMMO";
        }
    }*/

    void printText()
    {
        text.text = "Shoot time: " + num_bullet;
    }
    public void SetSpawner(PowerUpSpawner s)
    {
        spawner = s;
    }
    void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
    }
}
