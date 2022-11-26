using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    private Transform spawn;
    public Animator animator;

    public float runSpeed = 40f;
    public float ladderSpeed = 30f;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    bool jump = false;
    bool crouch = false;
    bool up = false;

    void Awake()
    {
        spawn = GameObject.Find("PlayerSpawn").GetComponent<Transform>();
    }

    void Start()
    {
        transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //verticalMove = Input.GetAxisRaw("Vertical") * ladderSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButton("Jump") && GetComponent<CheckCollisions>().isGrounded())
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        else
        {
            jump = false;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
/*
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            up = true;
        }
        else
        {
            up = false;
        }
*/
    }

    private void FixedUpdate()
    {
        controller.setMovementVars(horizontalMove * Time.fixedDeltaTime, crouch, jump, verticalMove * Time.fixedDeltaTime);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
