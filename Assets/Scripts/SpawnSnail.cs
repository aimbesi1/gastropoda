using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnail : MonoBehaviour
{
    public Transform m_SpawnPoint;
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
        Instantiate(m_Snail, m_SpawnPoint.transform.position, Quaternion.identity);
    }
}
