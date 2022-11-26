using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player"))
        {
            LoadLevel();

            if (SceneManager.GetActiveScene().name == "Level 2.1") // Player will not have weapons when change era
            {
                PlayerPrefs.SetInt("PlayerMaxHealth", 100); // Set player max health
                PlayerPrefs.SetInt("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth")); // set player initial health to max health
                // Intialize Player with no weapon
                PlayerPrefs.SetInt("HasGun", 0);
                PlayerPrefs.SetInt("HasSword", 0);
                PlayerPrefs.SetInt("HasSaltGun", 0);

                PlayerPrefs.SetInt("Clip", 3); // Store the number of clip in the normal gun
                PlayerPrefs.SetInt("Ammo", 12); //Store the number of bullet in the normal gun
                PlayerPrefs.SetInt("Throwtime", 2); // Store the throw time for the sword
                PlayerPrefs.SetInt("Shoottime", 10); // Store the shoot time of the salt gun
            }
        }
    }
}
