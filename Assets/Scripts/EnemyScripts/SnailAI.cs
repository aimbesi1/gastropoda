using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class modeling the snail's AI.
// The snail will always try to move horizontally towards the player.
public class SnailAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SnailPipeMovement pipeAI;
    [SerializeField] private SnailVars snailVars;
    public playerHealth pHealth;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D[] collider2D;
    [SerializeField] private float speed = 0;
    AudioSource audio;

    public bool grounded;
    bool isMoving = false;

    [SerializeField] private PipeSystem pipeSystem;

    [SerializeField] private int currentPointIndex = 0;

    //Snail will get faster with increments
    [SerializeField] private float increaseSpeedTimer = 5f; // After a set timer of seconds
    [SerializeField] private float speedToIncreaseBy = 1f;  // Increase the snail speed by this
    [SerializeField] private float maxSpeed = 5f;           // The snail cannot get faster than this


    private void Start()
    {
        pipeAI = GetComponent<SnailPipeMovement>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        snailVars = GetComponent<SnailVars>();
        collider2D = GetComponents<Collider2D>();
        audio = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");  //When snail spawns, it will find the player
        pHealth = player.GetComponent<playerHealth>();
        InvokeRepeating("DoTimer", 0.001f, increaseSpeedTimer);
    }

    private void DoTimer()
    {
        gameObject.SendMessage("IncreaseSpeed", speedToIncreaseBy);
    }

    private void IncreaseSpeed(float s)
    {
        if (snailVars.speed <= maxSpeed)
            snailVars.speed += s;
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
        if (rigidbody2D.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;
        if (isMoving)
        {
            if (!audio.isPlaying)
                audio.Play();
        }
        else
            audio.Stop();
    }

    private void Move()
    {
        //distance = Vector2.Distance(transform.position, player.transform.position);

        // Get the normalized direction to the player
        //Debug.Log("Running Move()");
        if(player != null)
        {
            if (pHealth.isInvisible == false)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;

                // Move the snail
                rigidbody2D.velocity = new Vector2(direction.x * snailVars.speed, rigidbody2D.velocity.y);
            }
            else
                speed = 0;
        }
        
        float velocity = rigidbody2D.velocity.x;

        if (velocity > 0f && !snailVars.m_FacingRight)
        {
            Flip();
        }
        else if (velocity < 0f && snailVars.m_FacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        snailVars.m_FacingRight = !snailVars.m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void slow()
    {
        speed -= 0.5f;
    }
}
