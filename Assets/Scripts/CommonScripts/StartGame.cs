using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code modified from https://www.youtube.com/watch?v=NRUk7YzXyhE
public class StartGame : MonoBehaviour
{
    public string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);

        PlayerPrefs.SetInt("SnailMaxHealth", 1500); // Set snail max health
        PlayerPrefs.SetInt("SnailCurrentHealth", PlayerPrefs.GetInt("SnailMaxHealth")); // Set snail initial health to max health

        PlayerPrefs.SetInt("IsBoss", 0);
        PlayerPrefs.SetInt("NumFight", 1);

        PlayerPrefs.SetInt("PlayerMaxHealth", 100); // Set player max health
        PlayerPrefs.SetInt("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth")); // set player initial health to max health

        PlayerPrefs.SetInt("PlayerCurrentShield", 0); // Set player initial shield to 0

        // Intialize Player with no weapon
        PlayerPrefs.SetInt("HasGun", 0);
        PlayerPrefs.SetInt("HasSword", 0);
        PlayerPrefs.SetInt("HasSaltGun", 0);

        PlayerPrefs.SetInt("HasInvinciblePower", 0);
        PlayerPrefs.SetInt("HasInvisiblePower", 0);
        PlayerPrefs.SetInt("HasTimePower", 0);

        PlayerPrefs.SetInt("Clip", 3); // Store the number of clip in the normal gun
        PlayerPrefs.SetInt("Ammo", 12); //Store the number of bullet in the normal gun
        PlayerPrefs.SetInt("Throwtime", 2); // Store the throw time for the sword
        PlayerPrefs.SetInt("Shoottime", 10); // Store the shoot time of the salt gun

        PlayerPrefs.SetFloat("SpeedRunTime", 0f); // Speedrun timer
        PlayerPrefs.SetInt("RespawnLimit", 3);
        if(!PlayerPrefs.HasKey("BestTime"))
        {
            PlayerPrefs.SetFloat("BestTime", 0f);
        }

        PlayerPrefs.SetString("CurrentScene", "");// Store the current scene
        PlayerPrefs.SetString("NextScene", "");

        PlayerPrefs.SetInt("GameComplete", 0);
    }
}
