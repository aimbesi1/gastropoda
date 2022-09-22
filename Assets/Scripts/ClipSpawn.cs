using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipSpawn : MonoBehaviour
{
    private float time = 2f;

    private bool hasCollide = false;

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
        Gun gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();
        if(gun != null && !hasCollide)
        {
            hasCollide = !hasCollide;
            Debug.Log("Player touch ClipSpawn --- ClipSpawn --> Weapons.addClip()");
            Destroy(gameObject);
            gun.addClip();
        }
    }
}
