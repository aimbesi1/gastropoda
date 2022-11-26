using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupStatus : MonoBehaviour
{
    playerHealth player;

    // Update is called once per frame
    void Update()
    {
        if (player.isInvincible == true)
        {
            Debug.Log("player is currently invincible");
        }
    }
}
