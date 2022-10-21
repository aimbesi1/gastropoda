using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class snailHealth : MonoBehaviour
{
    public int maxHealth = 500000;
    public int currentHealth;
    public int dmg = 100;
    public TMP_Text text;

    private bool has_Collide = false;

    public snailHealthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        printText();
    }


    public void takeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthbar.setHealth(currentHealth);
        printText();
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void printText()
    {
        text.text = currentHealth + "/" + maxHealth;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if(player != null && !has_Collide)
        {
            has_Collide = !has_Collide;
            player.takeDamage(dmg);
            has_Collide = !has_Collide;
        }
    }
}
