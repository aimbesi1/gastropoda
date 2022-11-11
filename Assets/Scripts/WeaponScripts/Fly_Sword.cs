using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Sword : MonoBehaviour
{
    private int speed = 20;
    private int dmg = 100;

    private float fly_time = 2f;
    
    public Rigidbody2D rb;

    private RaycastHit2D raycast;
    public Transform rayposition;

    // Start is called before the first frame update
    void Start()
    { 
        rb.velocity = transform.right * speed;  // Initialize the speed of the flying sword
    }

    void Update()
    {
        int layermask = 1 << 8;
        layermask = ~layermask;
        raycast = Physics2D.Raycast(rayposition.position, transform.right * speed, Mathf.Infinity, layermask);
        if(raycast.collider.CompareTag("SpawnObj"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindWithTag("SpawnObj").GetComponent<Collider2D>());   // Ignore collision between the sword and the spawn object
        }
        if(raycast.collider.name == "Lever")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Lever").GetComponent<Collider2D>());             // Ignore the collision between the sword and the lever mechanics
        }
        Destroy(gameObject, fly_time);          // Destroy fly_sword after an amount of time fly
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {   
        GameObject ground = GameObject.FindWithTag("Ground");
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if (ground != null)
        {
            Destroy(gameObject); // Destroy the fly sword if it hit the ground
        }
        if (snail != null)
        {
            snail.takeDamage(dmg); // Deal damage to the snail then destroy the object
            Destroy(gameObject);
        }
    }
}
