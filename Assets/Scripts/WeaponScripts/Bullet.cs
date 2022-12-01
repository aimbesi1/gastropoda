using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20;
    private int dmg = 50;
    public float knockbackMultiplier = 2.5f; // Multiplier for hitting the player
    public float hitMultiplier = 7f;    // Multiplier for hitting physics blocks

    private float fly_time = 2f;
    
    public Rigidbody2D rb;
    [SerializeField]private bool friendly = true; // Determines whether this is a player-fired or enemy-fired bullet

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
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        GameObject ground = GameObject.FindWithTag("Ground");
        dummy dummy = hitInfo.GetComponent<dummy>();
        if (ground != null)
        {
            Rigidbody2D otherRB = hitInfo.GetComponent<Rigidbody2D>();
            if (otherRB != null)
            {
                Vector2 force = new Vector2(rb.velocity.x, rb.velocity.y + 10) * hitMultiplier;
                otherRB.AddForce(force, ForceMode2D.Impulse);
            }
            Destroy(gameObject); // Destroy if touch ground
        }
        if(snail != null && PlayerPrefs.GetInt("IsBoss") == 1 && friendly)
        {
            snail.takeDamage(dmg); // Deal damage to snail
            Destroy(gameObject);
        }
        if (dummy != null && friendly)
        {
            dummy.takeDamage(dmg);
            Destroy(gameObject);
        }
        if(!friendly && player != null)
        {
            player.takeDamage(dmg);
        }
    }
    public void SetDamage(int value)
    {
        dmg = value;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetFriendly(bool value)
    {
        friendly = value;
    }
}
