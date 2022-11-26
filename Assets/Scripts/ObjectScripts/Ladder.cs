using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private int speed = 5;
    private bool isClimb;
    private bool isLadder;
    private float vertical;

    private GameObject topLadder;
    private GameObject bottomLadder;

    [SerializeField] private Rigidbody2D rb;

    void Awake()
    {
        topLadder = GameObject.Find("Top");
        bottomLadder = GameObject.Find("Bottom");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        if(hitInfo.name == "Bottom")
        {
            vertical = 1;
            topLadder.SetActive(false);
        }
        else if(hitInfo.name == "Top")
        {
            vertical = -1;
            bottomLadder.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimb = false;
            if(!topLadder.activeSelf)
            {
                topLadder.SetActive(true);
            }
            else if(!bottomLadder.activeSelf)
            {
                bottomLadder.SetActive(true);
            }
        }
    }

    void Update()
    {
        if(isLadder && Mathf.Abs(vertical) > 0f && Input.GetKeyDown(KeyCode.E))
        {
            isClimb = true;
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
