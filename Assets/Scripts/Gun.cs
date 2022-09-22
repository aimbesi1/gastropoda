using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bullet;
    public TMP_Text text;
    public GameObject player;

    public int bullet = 12;
    public int ammo;
    public int clip;

    public float reload_timer = 2f;
    public bool is_reload = false;

    // Start is called before the first frame update
    void Start()
    {
        ammo = bullet;
        clip = 1;
        printText();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("Fire1") && ammo > 0 && clip >= 1)
        {
            Shoot();
            ammo--; 
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            Destroy(gameObject);
        }

        if(reload_timer > 0 && ammo <= 0 && clip > 1)
        {
            reload_timer -= Time.deltaTime;
            is_reload = true;
        }

        if(reload_timer <= 0)
        {
            reload();
            reload_timer = 2f;
            is_reload = false;
        }
        printText();
        Parent(player);
    }

    void Shoot()
    {
        Instantiate(Bullet, firepoint.position, firepoint.rotation);
    }

    void reload()
    {
        clip--;
        ammo = bullet;
    }

    void printText()
    {
        if(is_reload)
        {
            text.text = "Reloading...";
        }
        else if(!is_reload && ammo > 0)
        {
            text.text = ammo + "/" + bullet + " --- Clip: " + clip;
        }
        else if (ammo <= 0)
        {
            text.text = "OUT OF AMMO";
        }
    }

    void Parent(GameObject parent)
    {
        gameObject.transform.parent = parent.transform;
    }

//NOT WORKING AS INTENDED --- Variable not update ("clip")  ???????
    public void addClip()
    {
        clip++;
        printText();
        Debug.Log("Gun called addClip");
    }
}
