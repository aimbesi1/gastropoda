using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public string startLevelName;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(startLevelName, LoadSceneMode.Single);
    }
}
