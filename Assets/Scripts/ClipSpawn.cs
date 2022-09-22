using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipSpawn : MonoBehaviour
{
    private float time = 2f;
    private int num_clip = 1;

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Weapons player = hitInfo.GetComponent<Weapons>();
        if(player != null)
        {
            Debug.Log("Player touch ClipSpawn --- ClipSpawn --> Weapons.addClip()");
            Destroy(gameObject);
            player.addClip(num_clip);
        }
    }
}
