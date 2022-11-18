using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirCannon : MonoBehaviour
{
    public GameObject CannonBullet;
    public Transform firepoint;

    public float cd_time = 2f;
    bool can_shoot = true;


    void Update()
    {
        Cooldown();
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo != null)
        {
            //if(hitInfo.CompareTag("Player") && can_shoot) // Check if the player is touching the cannon and if key "E" is pressed
            if (hitInfo.CompareTag("Player") && can_shoot) // Check if the player is touching the cannon and if key "E" is pressed
            {
                Debug.Log("Player touch");
                Debug.Log("E Pressed");
                Instantiate(CannonBullet, firepoint.position, firepoint.rotation); //Shoot out a bullet
                can_shoot = false;
            }
        }
    }

    void Cooldown() //cool down the cannon
    {
        if(!can_shoot && cd_time > 0)
        {
            cd_time -= Time.deltaTime;
        }
        if(cd_time <= 0)
        {
            cd_time = 2f;
            can_shoot = true;
        }
    }
}
