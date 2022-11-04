using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : SpawnedItem
{
    public override void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            Weapons playerWeapons = hitInfo.GetComponent<Weapons>();
            if (playerWeapons != null)
            {
                if (!IsIndependent() && GetPowerUpSpawner() != null)
                {
                    GetPowerUpSpawner().gun_limit--;
                }
                playerWeapons.getGun();
            }

            base.OnTriggerEnter2D(hitInfo);
        }

    }
}
