using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailPipes : MonoBehaviour
{
    public Transform[] m_TransitionPoint;
    public GameObject m_Snail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Invoke("SpawnEnemySnail", 2f); //Invokes after 2 secs
        }
    }

    void SpawnEnemySnail()
    {
        //Spawn your impending doom
        Instantiate(m_Snail, m_TransitionPoint[0].transform.position, Quaternion.identity);
    }
}
