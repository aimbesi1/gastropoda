using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnail : MonoBehaviour
{
    public GameObject m_Snail;

    public float graceTimer = 5f; //How many seconds until snail spawns

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemySnail", graceTimer); //Invokes after set timer
    }


    void SpawnEnemySnail()
    {
        //Spawn your impending doom
        m_Snail.GetComponent<Transform>().position = transform.position;
    }
}
