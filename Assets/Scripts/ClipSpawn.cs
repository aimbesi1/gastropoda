using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipSpawn : MonoBehaviour
{
    private float time = 6f;
    private bool hasCollide = false;

    void Update()
    {
        Destroy(gameObject, time); //Destroy itself over a period of time
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Weapons player = hitInfo.GetComponent<Weapons>(); 
        if(player != null && !hasCollide) //Player interact with the spawn obj
        {
            hasCollide = !hasCollide;
            Destroy(gameObject);
            player.storeClip();
        }
    }

}
