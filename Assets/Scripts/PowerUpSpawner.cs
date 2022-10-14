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
    public int sword_limit = 1;

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
        for (int i = 0; i < powerupLocations.Length; i++)
        {
            Instantiate(pwerParticleSpawn, powerupLocations[i]);
        }
    }

    void WeaponSpawn()
    {
        for (int i = 0; i < weaponLocations.Length; i++)
        {
            Instantiate(weaponParticleSpawn, weaponLocations[i]);
        }
    }
}
