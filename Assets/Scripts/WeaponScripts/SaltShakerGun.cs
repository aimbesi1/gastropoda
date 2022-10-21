using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaltShakerGun : MonoBehaviour
{
    private int num_bullet = 10;
    public Transform firepoint;
    public GameObject Bullet;
    private int bulletVel = 100;

    private PowerUpSpawner spawner;
    public Weapons weapons;
    private GameObject player;
    public TMP_Text text;

    private int ammo;
    private int clip;

    private float reload_timer = 2f;
    private bool is_reload = false;

    // Start is called before the first frame update
    void Start()
    {
        ammo = num_bullet;
        clip = 2;
        printText();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammo > 0 && clip >= 1 && !is_reload)
        {
            shoot();
            ammo--;
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            gameObject.SetActive(false);
            weapons.has_gun = false;
            if (spawner != null)
                spawner.saltgun_limit++;
        }
        if (reload_timer > 0 && ((ammo <= 0 && clip > 1) || Input.GetButtonDown("Reload")))
        {
            ammo = 0;
            reload_timer -= Time.deltaTime;
            is_reload = true;
        }

        if (reload_timer <= 0)
        {
            reload();
            reload_timer = 2f;
            is_reload = false;
        }
        printText();
        SetParent(player.transform);
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
    void reload()
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
