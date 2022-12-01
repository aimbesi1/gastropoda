using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class modeling the snail's AI.
// The snail will always try to move horizontally towards the player.
public class MiniSnailAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public LayerMask playerLayer;
    public playerHealth pHealth;
    [SerializeField] private SnailPipeMovement pipeAI;
    [SerializeField] private SnailVars snailVars;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D[] collider2D;
    [SerializeField] private Transform frontOffset;
    [SerializeField] private LayerMask groundLayer;

    private float gravity; // Save gravity value
    [SerializeField] private float baseSpeed = 2;
    private float facingAngle = 60f; // 1 = normalized direction is perfectly towards the player
    [SerializeField] private float chargeSpeed = 5; // Speed when "charging" at the player
    [SerializeField] private float lookDistance = 35; // Maximum distance from which it can detect players

    private Vector2 m_direction = Vector2.right;

    [SerializeField] private bool facingWall = false;


    private void Start()
    {
        pipeAI = GetComponent<SnailPipeMovement>();
        snailVars = GetComponent<SnailVars>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
        collider2D = GetComponents<Collider2D>();
        player = GameObject.FindWithTag("Player");  // When snail spawns, it will find the player
        pHealth = player.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pipeAI.inPipe && snailVars.grounded)
        {
            Move();
        }

        else if (pipeAI.inPipe)
        {
            pipeAI.MoveInPipe();
        }
    }

    // The mini snail will just alternate between moving left and right.
    private void Move()
    {
        facingWall = Physics2D.OverlapBox(frontOffset.position, new Vector2(0.1f, 0.3f), 0, groundLayer);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        // The mini snail will move faster if it is facing the player and on nearly the same vertical level

        // The mini snail will move faster if it is facing the player and on nearly the same vertical level
        if (!pHealth.isInvisible && IsFacingPlayer(direction) && FoundPlayer())
        {
            snailVars.speed = chargeSpeed;
        }
        else
        {
            snailVars.speed = baseSpeed;
        }


        // Move the snail
        rigidbody2D.velocity = new Vector2(m_direction.x * snailVars.speed, rigidbody2D.velocity.y);
        float velocity = rigidbody2D.velocity.x;

        if (facingWall && !snailVars.m_FacingRight)
        {
            Flip();
        }
        else if (facingWall && snailVars.m_FacingRight)
        {
            Flip();
        }
    }

    private bool IsFacingPlayer(Vector2 direction)
    {
        return (direction.x > 0 && snailVars.m_FacingRight) || (direction.x < 0 && !snailVars.m_FacingRight);
    }

    private bool FoundPlayer()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right, lookDistance, playerLayer);
        return raycast.collider != null;
    }

    private void Flip()
    {
        snailVars.m_FacingRight = !snailVars.m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
        m_direction *= -1;
    }
}