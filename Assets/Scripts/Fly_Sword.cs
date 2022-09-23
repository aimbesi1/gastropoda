using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Sword : MonoBehaviour
{
    private int speed = 20;
    private int dmg = 50;

    private float fly_time = 2f;
    
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        if(fly_time > 0f)
        {
            fly_time -= Time.deltaTime;
        }
        if(fly_time <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {   
        GameObject obj = GameObject.FindWithTag("SpawnObj");
        GameObject ground = GameObject.FindWithTag("Ground");
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if (ground != null)
        {
            Destroy(gameObject);
        }
        if(snail != null)
        {
            snail.takeDamage(dmg);
            Destroy(gameObject);
        }
        if(obj != null)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
        }

    }
}
