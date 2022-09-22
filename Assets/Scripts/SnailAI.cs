using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class modeling the snail's AI.
// The snail will always try to move horizontally towards the player.
public class SnailAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D[] collider2D;
    private float gravity; // Save gravity value
    [SerializeField] private float speed = 0;
    private float pipeSpeed;

    private float distance;

    [SerializeField] private bool grounded;

    [SerializeField] private bool inPipe;
    [SerializeField] private PipeSystem pipeSystem;
    [SerializeField] private Transform currentPoint;
    [SerializeField] private Transform nextPoint;
    [SerializeField] private int nextPointIndex;

    //Snail will get faster with increments
    [SerializeField] private float increaseSpeedTimer = 5f; // After a set timer of seconds
    [SerializeField] private float speedToIncreaseBy = 1f;  // Increase the snail speed by this
    [SerializeField] private float maxSpeed = 5f;           // The snail cannot get faster than this


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
        collider2D = GetComponents<Collider2D>();
        player = GameObject.FindWithTag("Player");  //When snail spawns, it will find the player
        InvokeRepeating("DoTimer", 0.001f, increaseSpeedTimer);
    }

    private void DoTimer()
    {
        gameObject.SendMessage("IncreaseSpeed", speedToIncreaseBy);
    }

    private void IncreaseSpeed(float s)
    {
        if (speed <= maxSpeed)
            speed += s;
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

    private void Move()
    {
        //distance = Vector2.Distance(transform.position, player.transform.position);

        // Get the normalized direction to the player
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Move the snail
        rigidbody2D.velocity = new Vector2(direction.x * speed, rigidbody2D.velocity.y);
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
}
