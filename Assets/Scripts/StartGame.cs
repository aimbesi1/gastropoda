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
    }
}
