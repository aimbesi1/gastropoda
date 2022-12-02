using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicScene : MonoBehaviour
{
    public string levelName;

    void Awake()
    {
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        Invoke("LoadLevel", 7.5f);
    }

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
    }
}
