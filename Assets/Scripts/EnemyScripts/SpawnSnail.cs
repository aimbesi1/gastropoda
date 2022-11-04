using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnail : MonoBehaviour
{
    public GameObject m_Snail;
    AudioSource audio;
    bool spawnOnce = false;

    //public float graceTimer = 3f; //How many seconds until snail spawns

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //Invoke("SpawnEnemySnail", graceTimer); //Invokes after set timer
    }


    public void SpawnEnemySnail()
    {
        //Invoke("SnailTimer", graceTimer); //Invokes after set timer
        SnailTimer();
    }

    void SnailTimer()
    {
        if(spawnOnce == false)
        {
            //Spawn your impending doom
            Instantiate(m_Snail, transform.position, transform.rotation);
            audio.Play();
            spawnOnce = true;
        }
        
    }
}
