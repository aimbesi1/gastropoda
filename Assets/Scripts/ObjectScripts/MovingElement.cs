using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElement : MonoBehaviour
{
    public bool loopThroughPoints; // If true, the object will visit the first waypoint after it reaches the last waypoint.

    public Transform movingObject; // The moving object itself
    private Rigidbody2D movingRB;

    private bool goingForwards = true; // Visit the point with a higher index if true, or the one with a lower index if false

    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int currentPointIndex = 0;
    [SerializeField] private float pointRadius = 0.5f; // The object will visit the next point once its distance to the current point <= this
    [SerializeField] private float waitTime;    // Time in seconds for the object to wait before visiting the next point
    private bool moving = true;
    void Start()
    {
        movingObject.transform.position = points[0].position;
        movingRB = movingObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (moving)
        {
            Vector2 direction = (points[currentPointIndex].position - movingObject.transform.position).normalized;
            // Go to the next point in the sequence
            movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, points[currentPointIndex].position, moveSpeed);
            //movingRB.velocity = direction * moveSpeed;

            if (Vector2.Distance(points[currentPointIndex].position, movingObject.transform.position) <= pointRadius)
            {
                // Stop movement until UpdatePointIndex is called
                movingRB.velocity = Vector2.zero;
                moving = false;
                Invoke("UpdatePointIndex", waitTime);
            }
        }
    }

    private void UpdatePointIndex()
    {
        moving = true;
        // Continue movement by getting the next point to travel to
        if (loopThroughPoints)
        {
            if (goingForwards)
            {
                currentPointIndex = (currentPointIndex + 1) % points.Length;
            }
            else
            {
                currentPointIndex = (currentPointIndex - 1) % points.Length;
            }
        }
        else
        {
            // Change direction if object is not looping and reaches the end/beginning of the array
            if ((goingForwards && currentPointIndex == points.Length - 1)
                || (!goingForwards && currentPointIndex == 0))
            {
                goingForwards = !goingForwards;
            }
            if (goingForwards)
            {
                currentPointIndex++;
            }
            else
            {
                currentPointIndex--;
            }
        }
    }
}
