using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShipSnailSpawn : MonoBehaviour
{
    public GameObject m_Snail;
    AudioSource audio;
    public waveMachenics wm;
    bool spawnOnce = false;

    public float graceTimer = 5f; //How many seconds until snail spawns

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(wm.waveEnded == true && spawnOnce == false)
        {
            Debug.Log("check");
            //Spawns the snail
            Invoke("SnailTimer", graceTimer); //Invokes after set timer
            
        }
    }

    void SnailTimer()
    {
        if (spawnOnce == false)
        {
            spawnOnce = true;
            //Spawn your impending doom
            Debug.Log("Spawning");
            Instantiate(m_Snail, transform.position, transform.rotation);
            audio.Play();
        }
    }
}
