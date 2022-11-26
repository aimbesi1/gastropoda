using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 20;
    private int dmg = 50;

    private float fly_time = 2f;

    private RaycastHit2D raycast;
    public Transform rayposition;
    
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
        GameObject ground = GameObject.FindWithTag("Ground");
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if (ground != null)
        {
            Destroy(gameObject); // Destroy if touch ground
        }
        if(snail != null)
        {
            snail.takeDamage(dmg); // Deal damage to snail
            Destroy(gameObject);
        }
        
    }
    
}
