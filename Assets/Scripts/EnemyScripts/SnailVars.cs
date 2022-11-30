using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailVars : MonoBehaviour
{
    public float gravity; // Save gravity value
    public float speed = 0;

    public bool m_FacingRight = true;

    public bool grounded;

    public SnailPipeMovement pipeAI;
    public Rigidbody2D rigidbody2D;
    public Collider2D[] collider2D;
    public GameObject player;
    void Start()
    {
        pipeAI = GetComponent<SnailPipeMovement>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
        collider2D = GetComponents<Collider2D>();
        player = GameObject.FindWithTag("Player");  //When snail spawns, it will find the player
        Physics2D.IgnoreLayerCollision(8, 8, true); // 8 = enemy layer
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") && !pipeAI.inPipe)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
