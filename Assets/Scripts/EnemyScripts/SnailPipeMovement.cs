using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailPipeMovement : MonoBehaviour
{
    private SnailVars snail;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D[] collider2D;

    [SerializeField] public bool inPipe = false;
    [SerializeField] public bool escapingGround = false;
    private float pipeSpeed;
    [SerializeField] private PipeSystem pipeSystem;
    [SerializeField] private int currentPointIndex = 0;
    [SerializeField] private float pointRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        snail = GetComponent<SnailVars>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponents<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Initialize pipe movement
        if (!inPipe && collision.gameObject.CompareTag("PipeEntrance"))
        {
            snail.grounded = false;
            inPipe = true;
            pipeSystem = collision.transform.GetComponentInParent<PipeSystem>();
            //foreach (Transform p in pipeSystem.points)
            //{
            //    Debug.Log(p);
            //}
            currentPointIndex = 0;
            pipeSpeed = pipeSystem.pipeSpeed;
            rigidbody2D.gravityScale = 0;
            EnableTrigger();
            rigidbody2D.velocity = Vector2.zero;
            //transform.position = currentPoint.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            escapingGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Do not collide with ground until snail has fully exited the pipe and left the ground it was stuck in
        if (escapingGround && !inPipe && collision.gameObject.CompareTag("Ground"))
        {
            DisableTrigger();
        }
        if (inPipe && collision.gameObject.CompareTag("Ground"))
        {
            escapingGround = false;
        }
    }

    public void MoveInPipe()
    {
        // Go to the next point in the sequence
        Vector2 direction = (pipeSystem.points[currentPointIndex].position - transform.position).normalized;
        rigidbody2D.velocity = new Vector2(direction.x * pipeSpeed, direction.y * pipeSpeed);

        //transform.position = Vector2.MoveTowards(transform.position, pipeSystem.points[currentPointIndex].position, pipeSpeed);

        UpdatePipePointIndex();
    }

    private void UpdatePipePointIndex()
    {
        // Continue pipe movement by getting the next point to travel to
        if (inPipe && Vector2.Distance(pipeSystem.points[currentPointIndex].position, transform.position) < pointRadius
            && (pipeSystem.points[currentPointIndex].gameObject.CompareTag("PipeMidpoint")
            || pipeSystem.points[currentPointIndex].gameObject.CompareTag("PipeEntrance")))
        {
            currentPointIndex += 1;
            //Debug.Log("Current point index: " + currentPointIndex);
            //currentPoint = pipeSystem.points[currentPointIndex];
        }

        // End pipe movement by re-enabling colliders and continuing normal movement
        if (inPipe && Vector2.Distance(pipeSystem.points[currentPointIndex].position, transform.position) < pointRadius
            && pipeSystem.points[currentPointIndex].gameObject.CompareTag("PipeExit"))
        {
            inPipe = false;
            currentPointIndex = 0;
            if (!escapingGround)
            {
                DisableTrigger();
            }
            rigidbody2D.gravityScale = snail.gravity;
            Vector2 direction = rigidbody2D.velocity.normalized;
            rigidbody2D.velocity = new Vector2(direction.x * pipeSystem.pipeLaunchSpeed, direction.y * pipeSystem.pipeLaunchSpeed);
        }
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
