using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltShakerGunSpawn : SpawnedItem
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
                    GetPowerUpSpawner().saltgun_limit--;
                }
                playerWeapons.getSaltGun(GetPowerUpSpawner());
            }

            base.OnTriggerEnter2D(hitInfo);
        }

    }
}
