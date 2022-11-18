using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class snailHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int dmg = 100;
    public TMP_Text text;

    public GameObject teleporter;
    bool is_boss;
    int num_fight;

    private bool has_Collide = false;

    public snailHealthbar healthbar;

    void Awake()
    {
        maxHealth = PlayerPrefs.GetInt("SnailMaxHealth");
        num_fight = PlayerPrefs.GetInt("NumFight");
        if (PlayerPrefs.GetInt("IsBoss") == 0)
        {
            is_boss = false;
        }
        else
        {
            is_boss = true;
        }
    }

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

    public void slow()
    {
        GetComponent<SnailAI>().slow();
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

    // Check whether or not this is a boss
    void BossFight()
    {
        if (is_boss)
        {
            teleporter = GameObject.FindWithTag("Teleporter");
            teleporter.SetActive(false);

            if (currentHealth == maxHealth / 3 * num_fight)
            {
                num_fight = PlayerPrefs.GetInt("NumFight");
                num_fight++;
                PlayerPrefs.SetInt("NumFight", num_fight);
                PlayerPrefs.SetInt("IsBoss", 0);

                teleporter.SetActive(true);

            }
        }
    }
}
