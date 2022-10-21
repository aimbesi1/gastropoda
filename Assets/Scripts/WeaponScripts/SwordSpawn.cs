using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawn : SpawnedItem
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
                    GetPowerUpSpawner().sword_limit--;
                }
                playerWeapons.getSword(GetPowerUpSpawner());
            }

            base.OnTriggerEnter2D(hitInfo);
        }

    }
}
