using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    private int speed = 20;
    private int dmg = 200;

    private float fly_time = 2f;

    
    public Rigidbody2D rb;

    // Start is called before the first frame update
     void Start()
    { 
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(gameObject, fly_time); // Destroy the bullet after a period of time
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {   
        
    }
}
