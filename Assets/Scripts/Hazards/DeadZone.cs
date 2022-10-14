using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform spawn;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        
        if(player != null && player.isInvincible == false)
        {
            player.takeDamage(200);
        }
        else if(player != null && player.isInvincible == true)
        {
            player.transform.position = spawn.transform.position;
        }
    }
}
