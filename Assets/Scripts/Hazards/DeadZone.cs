using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform spawn;
    private PlayerInventory inventory;
    private playerHealth player;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth playerH = hitInfo.GetComponent<playerHealth>();
        
        if(playerH != null && playerH.isInvincible == false)
        {
            playerH.takeDamage(200);
        }
        else if(playerH != null && playerH.isInvincible == true)
        {
            Invoke("DestroyTotem", .5f);
        }
    }

    void DestroyTotem()
    {
        inventory.Totemslot.SetActive(false);
        player.transform.position = spawn.transform.position;
        Debug.Log("no longer invincible");
        player.SetDamageable();
    }
}
