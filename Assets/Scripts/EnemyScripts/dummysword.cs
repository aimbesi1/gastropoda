using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummysword : MonoBehaviour
{
    int dmg = 50;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if(player != null)
        {
            player.takeDamage(dmg);
        }
    }
}
