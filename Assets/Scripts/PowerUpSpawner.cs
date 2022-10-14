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
    public int salt_gun_limit = 1;

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else if(time <= 0){
            for (int i = 0; i < powerupLocations.Length; i++)
            {
                Instantiate(pwerParticleSpawn, powerupLocations[i]);
            }
            time = 6f;
        }
    }

/*

    ------------------------REFERENCES FOR SPAWNER-----------------------------------

    void Spawn()
    {
        int rand1 = Random.Range(0, 6);
        int rand2 = Random.Range(0, 3);
        if (rand1 == 1)
        {
            Instantiate(shield, pts[rand2].position, pts[rand2].rotation); //SHIELD Spawn
        }
        else if (rand1 == 2)
        {
            Instantiate(heart, pts[rand2].position, pts[rand2].rotation); // HEALTH Spawn
        }
        else if (rand1 == 3 && gun_limit <= 0)
        {
            Instantiate(clip, pts[rand2].position, pts[rand2].rotation); // AMMO Spawn
        }
        else if (rand1 == 4 && gun_limit > 0)
        {
            Instantiate(gun, pts[rand2].position, pts[rand2].rotation); // GUN Spawn

        }
        else if (rand1 == 5 && sword_limit > 0)
        {
            Instantiate(sword, pts[rand2].position, pts[rand2].rotation); // SWORD Spawn
        }
    }
*/
}
