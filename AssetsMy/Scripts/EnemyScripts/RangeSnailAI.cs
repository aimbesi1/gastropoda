using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class modeling the snail's AI.
// The snail will always try to move horizontally towards the player.
public class RangeSnailAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public playerHealth pHealth;
    [SerializeField] private SnailVars snailVars;
    [SerializeField] private Cannon cannon;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D[] collider2D;
    [SerializeField] private Transform frontOffset;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float baseSpeed = 2;
    private float facingAngle = 0.95f; // 1 = normalized direction is perfectly towards the player
    [SerializeField] private float aimingSpeed = 1;

    private Vector2 m_direction = Vector2.right;

    [SerializeField] private bool facingWall = false;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        snailVars = GetComponent<SnailVars>();
        collider2D = GetComponents<Collider2D>();
        player = GameObject.FindWithTag("Player");  // When snail spawns, it will find the player
        pHealth = player.GetComponent<playerHealth>();
        Physics2D.IgnoreLayerCollision(8, 8, true); // 8 = enemy layer
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!snailVars.pipeAI.inPipe && snailVars.grounded && player != null)
        {
            cannon.EnableCannon();
            Move();
        }
        else if (snailVars.pipeAI.inPipe)
        {
            cannon.DisableCannon();
            snailVars.pipeAI.MoveInPipe();
        }
    }

    // The mini snail will just alternate between moving left and right.
    private void Move()
    {
        // Get the normalized direction to the player
        //facingWall = Physics2D.OverlapBox(frontOffset.position, new Vector2(0.1f, 0.3f), 0, groundLayer);
        m_direction = (player.transform.position - transform.position).normalized;
        
        if (cannon.aiming)
        {
            snailVars.speed = aimingSpeed;
        }
        else
        {
            snailVars.speed = baseSpeed;
        }
        
        // Move the snail
        // The snail will keep moving straight forwards if the player is invisible.
        if (!pHealth.isInvisible)
        {
            if (m_direction.x > 0)
            {
                rigidbody2D.velocity = new Vector2(snailVars.speed, rigidbody2D.velocity.y);
            }
            else if (m_direction.x < 0)
            {
                rigidbody2D.velocity = new Vector2(-snailVars.speed, rigidbody2D.velocity.y);
            }
        }
        

        float velocity = rigidbody2D.velocity.x;
        
        if (velocity > 0f && !snailVars.m_FacingRight)
        {
            //Debug.Log("Velocity > 0 and not facing right");
            Flip();
        }
        else if (velocity < 0f && snailVars.m_FacingRight)
        {
            //Debug.Log("Velocity < 0 and facing right");

            Flip();
        }
    }

    
    private void Flip()
    {
        Debug.Log("m_FacingRight: " + snailVars.m_FacingRight);
        Debug.Log("Velocity:" + rigidbody2D.velocity.x);
        snailVars.m_FacingRight = !snailVars.m_FacingRight;
        
        transform.Rotate(0f, 180f, 0f);
    }
}
