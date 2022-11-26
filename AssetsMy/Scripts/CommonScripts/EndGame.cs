using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public string levelName;

    public void Respawn()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("CurrentScene"), LoadSceneMode.Single);
    }

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);

        PlayerPrefs.DeleteAll();
        
    }
}
