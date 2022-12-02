using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public string levelName;

    public void Respawn()
    {
        PlayerPrefs.SetInt("PlayerMaxHealth", 100); // Set player max health
        PlayerPrefs.SetInt("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth")); // set player initial health to max health

        PlayerPrefs.SetInt("PlayerCurrentShield", 0); // Set player initial shield to 0
        
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("CurrentScene"), LoadSceneMode.Single);
    }

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        
    }
}
