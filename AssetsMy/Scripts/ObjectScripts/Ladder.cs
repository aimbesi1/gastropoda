using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private int speed = 5;
    public bool isClimb;
    public bool isLadder;
    private float vertical;

    private GameObject topLadder;
    private GameObject bottomLadder;

    [SerializeField] private Rigidbody2D rb;


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }

    void Update()
    {
        if(isLadder)
        {
            vertical = 1;
        }
        else
        {
            vertical = -1;
        }
        if(isLadder && Mathf.Abs(vertical) > 0f && Input.GetAxisRaw("Vertical") > 0)
        {
            isClimb = true;
        }
        else
        {
            isClimb = false;
        }
        
    }

    void FixedUpdate()
    {
        if(isClimb)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 5.5f;
        }
    }
}
