using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BifrostParticle : MonoBehaviour
{
    public GameObject[] powerups;
    public Transform PwupLocation;
    public bool isWeapon;
    public PowerUpSpawner mainSpawner;
    // Start is called before the first frame update
    void Start()
    {
        mainSpawner = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();

        if(isWeapon)                                                 //Spawn stuff
        {
            Invoke("PowerupSpawn", .7f);
        }
        else
        {
            Invoke("WeaponSpawn", .7f);
        }
        
        Destroy(gameObject, 1.8f);
    }

    void PowerupSpawn()
    {
        Instantiate(powerups[Random.Range(0, powerups.Length)], PwupLocation.position, PwupLocation.rotation);
    }

    void WeaponSpawn()
    {
        int num = Random.Range(0, powerups.Length);
        if(num == 1 &&  mainSpawner.gun_limit > 0)
        {
            Instantiate(powerups[num], PwupLocation.position, PwupLocation.rotation);
        }
        else if (num == 2 && mainSpawner.sword_limit > 0)
        {
            Instantiate(powerups[num], PwupLocation.position, PwupLocation.rotation);
        }
        else if (num == 3 && mainSpawner.saltgun_limit > 0)
        {
            Instantiate(powerups[num], PwupLocation.position, PwupLocation.rotation);
        }
    }
}
