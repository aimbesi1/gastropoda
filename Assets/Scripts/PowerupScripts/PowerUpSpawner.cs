using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public Transform[] powerupLocations;    //array for powerup spawn locations
    public Transform[] weaponLocations;     //array for weapon spawn locations
    public GameObject pwerParticleSpawn;    //for powerup items
    public GameObject weaponParticleSpawn;  //for weapons
    public float time = 6f;         //time in between item respawns

    public int gun_limit = 1;       //limits how many times weapons are picked up
    public int saltgun_limit = 1;
    public int sword_limit = 1;

    void Awake()                                                      // This thing check whether or not the player has already own a specific weapon
    {
        if(PlayerPrefs.GetInt("HasGun") == 0)
        {
            gun_limit = 1;
        }
        else
        {
            gun_limit = 0;
        }

        if(PlayerPrefs.GetInt("HasSword") == 0)
        {
            sword_limit = 1;
        }
        else
        {
            sword_limit = 0;
        }

        if(PlayerPrefs.GetInt("HasSaltGun") == 0)
        {
            saltgun_limit = 1;
        }
        else
        {
            saltgun_limit = 0;
        }
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else if(time <= 0){
            PowerupSpawn();
            WeaponSpawn();
            time = 6f;
        }
    }

    void PowerupSpawn()
    {
        pwerParticleSpawn.GetComponent<BifrostParticle>().isWeapon = false; // check if this is a weapon spawner
        for (int i = 0; i < powerupLocations.Length; i++)
        {
            Instantiate(pwerParticleSpawn, powerupLocations[i]);
        }
    }

    void WeaponSpawn()
    {
        weaponParticleSpawn.GetComponent<BifrostParticle>().isWeapon = true; // check if this is weapon spawner
        for (int i = 0; i < weaponLocations.Length; i++)
        {
            Instantiate(weaponParticleSpawn, weaponLocations[i]);
        }
    }
}