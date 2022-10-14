using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class modeling the snail's AI.
// The snail will always try to move horizontally towards the player.
public class SnailMiniAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SnailPipeMovement pipeAI;
    [SerializeField] private SnailVars snailVars;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D[] collider2D;
    [SerializeField] private Transform frontOffset;
    [SerializeField] private LayerMask groundLayer;

    private float gravity; // Save gravity value
    [SerializeField] private float baseSpeed = 2;
    private float facingAngle = 0.95f; // 1 = normalized direction is perfectly towards the player
    [SerializeField] private float chargeSpeed = 5; // Speed when "charging" at the player

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
        if ((direction.x > facingAngle && snailVars.m_FacingRight) || (direction.x < -facingAngle && !snailVars.m_FacingRight))
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !pipeAI.inPipe)
        {
            snailVars.grounded = true;
        }
        else
        {
            snailVars.grounded = false;
        }
    }

    private void Flip()
    {
        snailVars.m_FacingRight = !snailVars.m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
        m_direction *= -1;
    }
}
