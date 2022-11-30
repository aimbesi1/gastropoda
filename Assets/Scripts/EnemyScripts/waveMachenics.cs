using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMachenics : MonoBehaviour
{
    public int num_wave = 5; // Number of wave

    public Transform[] spawn_point; // array to store where the enemy will spawn

    public GameObject[] Enemy; // array to store the type of the enemy

    public float spawn_timer = 5f;// Timer for each wave to spawn

    public GameObject teleporter; // Store the prefab teleporter

    public bool waveEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        teleporter.SetActive(false); //set the teleporter to false
        //Spawn();
        //num_wave--;
    }

    // Update is called once per frame
    void Update()                                               //When timer end, spawn another wave
    {
        if (!waveEnded)
        {
            if (spawn_timer > 0)
            {
                spawn_timer -= Time.deltaTime;
            }
            if (spawn_timer < 0)
            {
                Spawn();
                num_wave--;
                spawn_timer = 5f;
            }
        }
        if(num_wave <= 0)
        {
            teleporter.SetActive(true); // when all the waves is gone, the teleporter pop up
            waveEnded = true;
        }
    }

    void Spawn()
    {
        for(int i = 0; i < Enemy.Length; i++)
        {
            for(int p = 0; p < spawn_point.Length; p++)
            {
                Instantiate(Enemy[i], spawn_point[p].position, spawn_point[p].rotation);
            }
            
        }
    }
}
