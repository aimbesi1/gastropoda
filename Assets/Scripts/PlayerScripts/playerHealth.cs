using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public Healthbar healthbar;
    public int maxHealth;
    public int currentHealth;

    public playerShieldbar shieldbar;
    public int maxShield = 100;
    public int currentShield;

    public PlayerInventory playerInventory;
    private SpriteRenderer rend;
    public float invisibleTimer = 3f;
    public bool isInvincible = false;
    public bool isInvisible = false;
    public bool hasInvis;

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
        if (PlayerPrefs.GetInt("HasInvisible") == 0)
        {
            hasInvis = false;
        }
        else
        {
            hasInvis = true;
        }
        rend = GetComponent<SpriteRenderer>();
        maxHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
        currentHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        currentShield = PlayerPrefs.GetInt("PlayerCurrentShield");
        healthbar.setMaxHealth(maxHealth);
        shieldbar.setShield(currentShield);
        printText();
    }

    public void Update()
    {
        if(Input.GetKey("4") && hasInvis == true) //if player has invisible powerup in inventory
        {                                         //on key press "4", the player will be invisible
            SetInvisible();
            PlayerPrefs.SetInt("HasInvisiblePower", 0);
        }
    }

    public void takeDamage(int dmg)
    {
        currentHealth -= dmg - currentShield;  // Deal dmg to shield before deal dmg to actual health
        currentShield -= dmg;
        if(currentShield < 0) // Set current shield to 0 if shield drop below 0 (UI purposes)
        {
            currentShield = 0;
        }
        healthbar.setHealth(currentHealth);
        PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);
        shieldbar.setShield(currentShield);
        PlayerPrefs.SetInt("PlayerCurrentShield", currentShield);
        printText();
        if(currentHealth <= 0) //If health drop to or below 0, player die
        {
            Destroy(gameObject);
            LoadLevel();
        }
    }

    // Deals damage and also adds a force to the player.
    public void takeDamage(int dmg, Vector2 force)
    {
        Debug.Log(force);
        GetComponent<PlayerController>().SetLadderState(false);
        rb.AddForce(force, ForceMode2D.Impulse);
        takeDamage(dmg);
    }

    void printText()
    {
        text.text = currentHealth + "/" + maxHealth;
        text2.text = currentShield + "/" + maxShield;
    }
    
    public void SetInvincible()
    {
        isInvincible = true;
        CancelInvoke("SetDamageable");                  //makes it so player can not get hurt
        PlayParticles();
        //Invoke("SetDamageable", invincibleTimer);     // after a set timer, player will be able to get hurt
    }

    public void InvisPickUp()                           //called when player first picks up the invisible powerup
    {
        hasInvis = true;
    }

    public void SetInvisible()                          //Set player to not be tracked by Enemy/invisible
    {
        //Debug.Log("invis");
        isInvisible = true;
        hasInvis = false;                               //player no longer has the power up in inventory
        rend.color = new Color(1f, 1f, 1f, .5f);        //turns the player about 50% transparent
        CancelInvoke("SetVisible");
        Invoke("SetVisible", invisibleTimer);
    }

    public void SetVisible()                            //enemy can track player again.
    {
        //Debug.Log("visible");
        isInvisible = false;
        rend.color = new Color(1f, 1f, 1f, 1f);         //turns player back to normal
        playerInventory.Invisslot.SetActive(false);
        CancelInvoke("SetInvisible");
    }

    public void SetDamageable()                         //falling will use up the powerup and the player will become vulnerable again
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

    public void Heal(int health) // Add health to player when player picked up health potion
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += health;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);
            healthbar.setHealth(currentHealth);
            printText();
        }
    }

    public void Shield(int amount) // Add shield to player when player picked up shield potion
    {
        if(currentShield < maxShield)
        {
            currentShield += amount;
            if(currentShield > maxShield)
            {
                currentShield = maxShield;
            }
            PlayerPrefs.SetInt("PlayerCurrentShield", currentShield);
            shieldbar.setShield(currentShield);
            printText();
        }
    }
}