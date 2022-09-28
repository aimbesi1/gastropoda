using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    private Transform spawn;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

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

        if (Input.GetButton("Jump"))
        {
            jump = true;
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
    }

    private void FixedUpdate()
    {
        controller.setMovementVars(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    }
}
