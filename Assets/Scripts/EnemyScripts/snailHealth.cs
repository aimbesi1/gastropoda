using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class snailHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int dmg = 100;
    public TMP_Text text;

    bool is_boss;

    private bool has_Collide = false;

    public Healthbar healthbar;

    public GameObject canvas;

    public string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
    }

    void Awake()
    {
        maxHealth = PlayerPrefs.GetInt("SnailMaxHealth");
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
        if(is_boss)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }


    public void takeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthbar.setHealth(currentHealth);
        PlayerPrefs.SetInt("SnailCurrentHealth", currentHealth);
        printText();
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            LoadLevel();
            PlayerPrefs.SetInt("GameComplete", 1);
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
        if(player != null)
        {
            player.takeDamage(dmg);
        }
    }

}
