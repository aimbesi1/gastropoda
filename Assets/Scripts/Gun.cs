using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bullet;
    public TMP_Text text;
    private GameObject player;

    private PowerUpSpawner spawn;
    public Weapons weapons;

    private RaycastHit2D raycast;

    private int bullet = 12;
    private int ammo;
    private int clip;

    private float reload_timer = 2f;
    private bool is_reload = false;

    // Start is called before the first frame update
    void Start()
    {
        ammo = bullet; //set the ammo to the max bullet the gun can have
        clip = 3; //set the amount of ammo clip the player can have
        printText();
        player = GameObject.FindWithTag("Player");
        spawn = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("Fire1") && ammo > 0 && clip >= 1 && !is_reload) //if press left mouse it will shoot out bullet whenever the gun still have ammo
        {
            Shoot();
            ammo--; 
        }
        else if(Input.GetButtonDown("Fire2")) //Throw the gun away if press right mouse
        {
            gameObject.SetActive(false);
            weapons.has_gun = false;
            spawn.gun_limit++;
        }

        if(reload_timer > 0 && ((ammo <= 0 && clip > 1) || Input.GetButtonDown("Reload"))) //Reload and reload timer
        {
            ammo = 0;
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
        SetParent(player.transform); //Move the gun with the player
    }

    public void addClip() //add 1 clip for the player
    {
        clip++;
    }

    void Shoot()
    {
        Instantiate(Bullet, firepoint.position, firepoint.rotation); //Spawn the bullet
    }

    void reload() //Reload func
    {
        clip--;
        ammo = bullet;
    }

    void printText() //Print out the detail of the gun (clip, ammo and whether or not the player is reloading)
    {
        if(is_reload)
        {
            text.text = "Reloading... " + Mathf.RoundToInt(reload_timer) + "s";
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

    void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent); //move the gun with the player by setting the gun as a child of the player
    }

}
