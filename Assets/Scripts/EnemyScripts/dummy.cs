using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour
{                                                                // Stat for the solider
    public int health = 100;
    public GameObject player;
    public Rigidbody2D rb;
    public bool isFacingRight = true;                             // Check if the solider is facing right

    public Transform eye_position;                               // Raycast for eye level
    public float hit_range = 10;

    public RaycastHit2D obj;

    public GameObject Sword;

    public GameObject SwingSword;
    public float hit_timer = 0.5f;                             //Sword animation stuff
    public bool can_swing = true;
    public float hit_cd = 2f;

    public int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        obj = Physics2D.Raycast(new Vector2(eye_position.position.x, eye_position.position.y), transform.right * speed, hit_range); //When see player in range, perform hit animation
        if(obj.distance <= hit_range && obj.collider != null)
        {
            if(obj.collider.CompareTag("Player")) //Do the animation if see the player
            {
                if(hit_timer > 0 && can_swing)
                {
                    SwingSword.SetActive(true);
                    Sword.SetActive(false);
                    hit_timer -= Time.deltaTime;
                }
                if(hit_timer < 0)
                {
                    SwingSword.SetActive(false);
                    Sword.SetActive(true);
                    hit_timer = 0.5f;
                    can_swing = false;
                }
                if(!can_swing && hit_cd > 0)
                {
                    hit_cd -= Time.deltaTime;
                }
                if(hit_cd <= 0)
                {
                    can_swing = true;
                }
            }
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate()                                                 //Tracking the player
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        
        if(rb.velocity.x > 0 && !isFacingRight)
        {
            Flip();
        }
        if(rb.velocity.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void takeDamage(int num)
    {
        health -= num;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
