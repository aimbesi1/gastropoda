using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnail : MonoBehaviour
{
    public GameObject m_Snail;
    AudioSource audio;

    public float graceTimer = 5f; //How many seconds until snail spawns

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Invoke("SpawnEnemySnail", graceTimer); //Invokes after set timer
    }


    void SpawnEnemySnail()
    {
        //Spawn your impending doom
        Instantiate(m_Snail,transform.position, transform.rotation);
        audio.Play();
    }
}
