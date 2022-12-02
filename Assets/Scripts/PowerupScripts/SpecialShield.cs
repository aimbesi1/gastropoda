using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShield : MonoBehaviour
{
    private PlayerInventory inventory;
    //public GameObject powerupItem;
    private bool hasCollide = false;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth player = collision.GetComponent<playerHealth>();
        GameObject obj = GameObject.FindWithTag("Bullet");
        if (obj != null && gameObject.GetComponent<Collider2D>().IsTouching(obj.GetComponent<Collider2D>()))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
        }
        if (player != null && hasCollide == false)
        {
            if (inventory.isFull[0] == false)
            {
                inventory.isFull[0] = true;
                hasCollide = true;
                player.SetInvincible();
                inventory.Totemslot.SetActive(true);
                PlayerPrefs.SetInt("HasInvinciblePower", 1);
            }
            Destroy(gameObject);
        }
    }
}
