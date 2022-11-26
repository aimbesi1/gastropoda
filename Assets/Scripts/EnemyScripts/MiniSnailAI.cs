using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class modeling the snail's AI.
// The snail will always try to move horizontally towards the player.
public class MiniSnailAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D[] collider2D;
    [SerializeField] private Transform frontOffset;
    [SerializeField] private LayerMask groundLayer;

    private float gravity; // Save gravity value
    [SerializeField] private float speed = 2;
    [SerializeField] private float baseSpeed = 2;
    private float facingAngle = 0.95f; // 1 = normalized direction is perfectly towards the player
    [SerializeField] private float chargeSpeed = 5;
    private float pipeSpeed;

    private bool m_FacingRight = true;
    private Vector2 m_direction = Vector2.right;

    [SerializeField] private bool grounded;
    [SerializeField] private bool facingWall = false;

    [SerializeField] private bool inPipe;
    [SerializeField] private PipeSystem pipeSystem;
    private Transform currentPoint;
    private Transform nextPoint;
    private int nextPointIndex;

    //Snail will get faster with increments
    [SerializeField] private float increaseSpeedTimer = 5f; // After a set timer of seconds
    [SerializeField] private float speedToIncreaseBy = 1f;  // Increase the snail speed by this
    [SerializeField] private float maxSpeed = 5f;           // The snail cannot get faster than this


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
        collider2D = GetComponents<Collider2D>();
        player = GameObject.FindWithTag("Player");  // When snail spawns, it will find the player
        Physics2D.IgnoreLayerCollision(8, 8, true); // 8 = enemy layer
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!inPipe && grounded)
        {
            Move();
        }

        else if (inPipe)
        {
            MoveInPipe();
        }
    }

    // The mini snail will just alternate between moving left and right.
    private void Move()
    {
        facingWall = Physics2D.OverlapBox(frontOffset.position, new Vector2(0.1f, 0.3f), 0, groundLayer);
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // The mini snail will move faster if it is facing the player and on nearly the same vertical level
            if ((direction.x > facingAngle && m_FacingRight) || (direction.x < -facingAngle && !m_FacingRight))
            {
                speed = chargeSpeed;
            }
            else
            {
                speed = baseSpeed;
            }
        }

        // Move the snail
        rigidbody2D.velocity = new Vector2(m_direction.x * speed, rigidbody2D.velocity.y);
        float velocity = rigidbody2D.velocity.x;

        if (facingWall && !m_FacingRight)
        {
            Flip();
        }
        else if (facingWall && m_FacingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !inPipe)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Initialize pipe movement
        if (!inPipe && collision.gameObject.CompareTag("PipeEntrance"))
        {
            grounded = false;
            inPipe = true;
            pipeSystem = collision.transform.GetComponentInParent<PipeSystem>();
            currentPoint = collision.transform;
            nextPointIndex = 1;
            nextPoint = pipeSystem.points[nextPointIndex];
            pipeSpeed = pipeSystem.pipeSpeed;
            rigidbody2D.gravityScale = 0;
            EnableTrigger();
            transform.position = currentPoint.position;
        }

        // Continue pipe movement by getting the next point to travel to
        if (inPipe && collision.gameObject.CompareTag("PipeMidpoint"))
        {
            currentPoint = collision.transform;
            nextPointIndex += 1;
            nextPoint = pipeSystem.points[nextPointIndex];
        }

        // End pipe movement by re-enabling colliders and continuing normal movement
        if (inPipe && collision.gameObject.CompareTag("PipeExit"))
        {
            inPipe = false;
            DisableTrigger();
            rigidbody2D.gravityScale = gravity;
            Vector2 direction = rigidbody2D.velocity.normalized;
            rigidbody2D.AddForce(new Vector2(direction.x * pipeSystem.pipeLaunchSpeed, direction.y * pipeSystem.pipeLaunchSpeed), ForceMode2D.Impulse);
        }
    }

    private void MoveInPipe()
    {
        // Go to the next point in the sequence
        Vector2 direction = (nextPoint.transform.position - transform.position).normalized;
        rigidbody2D.velocity = new Vector2(direction.x * pipeSpeed, direction.y * pipeSpeed);
    }

    private void EnableTrigger()
    {
        foreach (Collider2D c in collider2D)
        {
            c.isTrigger = true;
        }
    }

    private void DisableTrigger()
    {
        foreach (Collider2D c in collider2D)
        {
            c.isTrigger = false;
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
        m_direction *= -1;
    }
}
