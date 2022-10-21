using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// Code modified from https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs

// Jumping code modified from https://mikeadev.net/2015/08/variable-jump-height-in-unity/
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private float moveMultiplier = 10f; // Number that multiplies horizontal/vertical movement. Could be written out by changing the speed numbers in PlayerMovement.cs

    [SerializeField] private float m_JumpVelocity = 20f;                       // Amount of initial velocity added when the player jumps.
    [SerializeField] private float m_cancelJumpVelocity = 7f;                   // Jump can no longer be canceled once the player's y velocity is less than this
                                                                                //[SerializeField] private float m_JumpAccel = 15f;                          // Amount of acceleration applied if the jump is extended.
    [SerializeField] private float m_JumpBrake = -50f;                         // Amount of deceleration applied at the end of a jump

    [SerializeField] private bool m_isJumping = false;                                           // For determining if the player is performing a jump
    [SerializeField] private bool m_wasJumping = false;                                         // For determining if the player is airborne due to a jump
    [SerializeField] private bool m_nearLadder = false;                                         // For determining if the player is near a ladder

    private bool newJumpInput = false;
    private float m_move = 0;
    private bool m_crouch = false;
    private bool m_jump = false;
    private float m_vertical = 0;
    private float m_gravity = 0;

    [SerializeField] private LayerMask m_LadderLayer;

    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;

    //[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching


    [SerializeField] private bool m_Grounded;            // Whether or not the player is grounded.

    [SerializeField] private bool m_onLadder = false;

    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D m_Collider2D;
    private CheckCollisions m_CheckCollisions;
    AudioSource audioSrc;
    bool isMoving = false;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    private float defaultYOffset = -0.18f;
    private float crouchYOffset = -1.54f;
    private float defaultYSize = 4.64f;
    private float crouchYSize = 2.3f;

    public bool timePowerActive = false;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Collider2D = GetComponent<BoxCollider2D>();
        m_CheckCollisions = GetComponent<CheckCollisions>();
        audioSrc = GetComponent<AudioSource>();
        m_gravity = m_Rigidbody2D.gravityScale;

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        Move(m_move, m_crouch, m_jump, m_vertical);

        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        if (m_CheckCollisions.isGrounded())
        {
            m_Grounded = true;
            if (!m_isJumping)
                m_wasJumping = false;
            if (!wasGrounded)
                OnLandEvent.Invoke();
        }
        if (m_Rigidbody2D.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;
        if (isMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
            audioSrc.Stop();

        // The following code is not the right way to implement the time powerup. It multiplies the velocity and gravity exponentially.
        //if (timePowerActive)
        //{
        //    Time.timeScale = 0.5f;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}
        //m_Rigidbody2D.velocity /= Time.timeScale;
        //m_Rigidbody2D.gravityScale /= Time.timeScale;
    }

    public void setMovementVars(float move, bool crouch, bool jump, float vertical)
    {
        m_move = move;
        m_crouch = crouch;
        m_jump = jump;
        m_vertical = vertical;
    }

    public void Move(float horizontal, bool crouch, bool jump, float vertical)
    {
        if (vertical > 0)
        {
            if (Physics2D.OverlapBox(transform.position, transform.localScale, 0, m_LadderLayer))
            {
                m_onLadder = true;
            }
            else
            {
                m_onLadder = false;
            }
        }

        if (m_onLadder)
        {
            HandleLadder(vertical);
        }
        else
        {
            m_Rigidbody2D.gravityScale = m_gravity;
            HandleCrouch(ref horizontal, ref crouch);
            MoveX(horizontal);
        }


        //m_Rigidbody2D.velocity = targetVelocity;

        // If the input is moving the player right and the player is facing left...
        if (horizontal > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontal < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        

        // If climbing a ladder, release from ladder with crouch + jump inputs
        if (m_onLadder && crouch && jump)
        {
            m_onLadder = false;
        }
        // Otherwise, release from ladder with a normal jump. Grounded behavior should be unchanged.
        else
        {
            HandleJump(jump);
        }
    }

    private void MoveX(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * moveMultiplier, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    private void HandleJump(bool jump)
    {
        // If the player should jump...
        // @JUMP
        if ((m_Grounded || m_onLadder) && jump && !m_isJumping && newJumpInput)
        {
            //Debug.Log("Initialized jump");
            // Add a vertical force to the player and set the appropriate flags.
            m_onLadder = false;
            m_isJumping = true;
            //m_Grounded = false;
            m_wasJumping = true;
            newJumpInput = false;

            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0); // Remove vertical velocity before applying force to ensure a full jump every time
            m_Rigidbody2D.AddForce(new Vector2(0, m_JumpVelocity), ForceMode2D.Impulse); // Velocity change = Force / Mass
        }
        // Cancel jump: Apply "brake" velocity to shorten jump height if player is still going upwards
        if (m_wasJumping && !jump && m_Rigidbody2D.velocity.y > 0)
        {
            m_isJumping = false;
            //Debug.Log("Brake force applied");
            m_Rigidbody2D.AddForce(new Vector2(0, m_JumpBrake), ForceMode2D.Force);
        }
        // End of jump
        if (m_isJumping && m_Rigidbody2D.velocity.y <= m_cancelJumpVelocity)
        {
            //Debug.Log("Jump ended");
            m_isJumping = false;
        }

        // This makes it so you can't input multiple jumps just by holding the button down.
        // You can still "buffer" a jump to come out as soon as the player hits the ground again by holding the button.
        if (!jump)
        {
            newJumpInput = true;
        }
    }

    private void HandleCrouch(ref float move, ref bool crouch)
    {
        // If crouching, check to see if the character can stand up
        if (crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CheckCollisions.m_CeilingCheck.position, m_CheckCollisions.k_CeilingRadius, m_CheckCollisions.m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on


        // If crouching
        if (crouch)
        {
            if (!m_wasCrouching)
            {
                m_wasCrouching = true;
                OnCrouchEvent.Invoke(true);
            }

            // Reduce the speed by the crouchSpeed multiplier
            move *= m_CrouchSpeed;

            // Resize main collider when crouching
            m_Collider2D.offset = new Vector2(m_Collider2D.offset.x, crouchYOffset);
            m_Collider2D.size = new Vector2(m_Collider2D.size.x, crouchYSize);
        }
        else
        {
            // Restore default collider dimensions when not crouching
            m_Collider2D.offset = new Vector2(m_Collider2D.offset.x, defaultYOffset);
            m_Collider2D.size = new Vector2(m_Collider2D.size.x, defaultYSize);

            if (m_wasCrouching)
            {
                m_wasCrouching = false;
                OnCrouchEvent.Invoke(false);
            }
        }
    }

    private void HandleLadder(float vertical)
    {
        m_Rigidbody2D.gravityScale = 0;
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(0, vertical * moveMultiplier);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
        // Multiply the player's x local scale by -1.
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }
}
