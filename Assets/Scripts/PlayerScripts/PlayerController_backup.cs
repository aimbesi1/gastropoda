using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Prototype for the player controller modeling basic player movement.
// Arrow keys to move, space to jump
// Tony Imbesi, 9/16/2022
public class PlayerController_backup : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerSpeed = 15;
    public float xAccel = 20;
    private float playerJump = 20;
    private float playerJumpAccel = 37.5f;
    private float playerJumpBrake = -40;

    private bool isJumping = false;
    private bool canJump = false;

    private int maxJumpTicks = 15;
    private int jumpTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move left or right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX(-xAccel);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX(xAccel);
        }

        // Initialize Jump
        //Debug.Log("Can jump: " + canJump);
        if (Input.GetKeyDown(KeyCode.Space) && canJump && !isJumping)
        {
            jumpTimer = 0;
            isJumping = true;
            canJump = false;
            rb.velocity = new Vector2 (rb.velocity.x, playerJump);
        }

        // Jump height increases with duration of button press
        if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimer < maxJumpTicks)
        {
            //Debug.Log("Adding jump acceleration");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + playerJumpAccel * Time.deltaTime);
            jumpTimer++;
            Debug.Log(jumpTimer);
        }

        /** End jump after releasing button or holding the button long enough */
        if (!Input.GetKey(KeyCode.Space) || !isJumping || jumpTimer >= maxJumpTicks)
        {
            isJumping = false;
            
            if (rb.velocity.y > 0)
            {
                //Debug.Log("Adding brake acceleration");
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + playerJumpBrake * Time.deltaTime);
            }      
        }

        
    }

    /**
    * Moves left or right by changing the player's acceleration.
    * 
    * @param ax the left or right acceleration. Negative = left, positive = right.
    *
    */
    private void moveX(float ax)
    {
        // Check to see if the player's velocity does not exceed the top speed.
        if ((-playerSpeed <= rb.velocity.x && ax < 0)
            || (playerSpeed >= rb.velocity.x && ax > 0))
        {
            // If so, apply more acceleration to the player
            rb.velocity = new Vector2(rb.velocity.x + (ax * Time.deltaTime), rb.velocity.y);
        }
        else
        {
            // No acceleration is applied if player is moving at top speed
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Ground collision");
            canJump = true;
        }
        if (other.gameObject.CompareTag("Snail"))
        {
            // Collided with an obstacle
            
            Debug.Log("Game over!!");
            Destroy(gameObject);
        }
    }
}
