using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        paused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        paused = true;
    }

    public void LoadScene(string sceneName)
    {
        Resume();
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    public void ShowOptions()
    {
        Debug.Log("Show options");
    }
}
