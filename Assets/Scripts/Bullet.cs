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
        rb.velocity = transform.right * speed; //Set the velocity for the bullet
    }

    void Update()
    {
        int layermask = 1 << 8;
        layermask = ~layermask;
        raycast = Physics2D.Raycast(rayposition.position, transform.right * speed, Mathf.Infinity, layermask);
        if(raycast.collider.CompareTag("SpawnObj"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindWithTag("SpawnObj").GetComponent<Collider2D>()); //Ignore collistion between the bullet and spawn obj
        }
        Destroy(gameObject, fly_time);
        
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {   
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if (hitInfo.CompareTag("Ground"))
        {
            Destroy(gameObject); //If hit ground destroy the bullet
        }
        if(snail != null)
        {
            snail.takeDamage(dmg); //Deal dmg if hit the snail then destroy the bullet
            Destroy(gameObject);
        }
        
    }
    
}
