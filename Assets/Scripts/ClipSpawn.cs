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
        Weapons player = hitInfo.GetComponent<Weapons>();
        Gun gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();
        if(player != null && gun != null && !hasCollide)
        {
            hasCollide = !hasCollide;
            Destroy(gameObject);
            gun.addClip();
        }
    }
}
