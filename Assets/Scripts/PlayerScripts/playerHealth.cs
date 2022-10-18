using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public playerHealthbar healthbar;
    public int maxHealth = 100;
    public int currentHealth;

    public playerShieldbar shieldbar;
    public int maxShield = 100;
    public int currentShield = 0;

    
    //public float invincibleTimer = 3f;
    public bool isInvincible = false;

    public TMP_Text text;
    public TMP_Text text2;

    public Rigidbody2D rb;

    public string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
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
        rb.velocity = transform.right * 20 + transform.up * 20;
        currentHealth -= dmg - currentShield;
        currentShield -= dmg;
        if(currentShield < 0 && !isInvincible) //if player is not invincible, player takes damage to shield
        {
            currentShield = 0;
        }
        healthbar.setHealth(currentHealth);
        shieldbar.setShield(currentShield);
        printText();
        if(currentHealth <= 0) //player takes damage to health
        {
            Destroy(gameObject);
            LoadLevel();
        }
    }
    
    void printText()
    {
        text.text = currentHealth + "/" + maxHealth;
        text2.text = currentShield + "/" + maxShield;
    }
    
    public void SetInvincible()
    {
        isInvincible = true;
        CancelInvoke("SetDamageable");              //makes it so player can not get hurt
        PlayParticles();
        //Invoke("SetDamageable", invincibleTimer);   // after a set timer, player will be able to get hurt
    }

    public void SetDamageable()
    {
        isInvincible = false;
        CancelInvoke("SetInvincible");
        StopParticles();
    }

    void PlayParticles()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
    }

    void StopParticles()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }

    public void Heal(int health)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += health;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthbar.setHealth(currentHealth);
            printText();
        }
    }

    public void Shield(int amount)
    {
        if(currentShield < maxShield)
        {
            currentShield += amount;
            if(currentShield > maxShield)
            {
                currentShield = maxShield;
            }
            shieldbar.setShield(currentShield);
            printText();
        }
    }

}