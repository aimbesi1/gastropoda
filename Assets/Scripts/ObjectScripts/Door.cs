using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public Transform openPoint; // Point where the door stays at while open
    public Transform closePoint; // Point where the door stays when closed
    public bool closeOnTimer = false; // Will automatically close after timer seconds if true
    public float timer = 4f;
    private float doorOpenTime = 0;
    private float pointRadius = 0.5f; // Maximum distance away from open or close points required to satisfy open/closed conditions

    [SerializeField] private float doorSpeed;

    private void Start()
    {
        if (isOpen)
        {
            // Start the door in the open state
            transform.position = openPoint.position;
        }
        else
        {
            // Start the door in the closed state
            transform.position = closePoint.position;
        }
    }
    private void FixedUpdate()
    {
        if (isOpen && Vector2.Distance(transform.position, openPoint.position) > pointRadius)
        {
            Debug.Log("Moving door to open position");
            Debug.Log(Vector2.Distance(transform.position, openPoint.position));

            // Move the door towards the open position at the doorSpeed
            transform.position = Vector2.MoveTowards(transform.position, openPoint.position, doorSpeed);
        }
        else if (!isOpen && Vector2.Distance(transform.position, closePoint.position) >= pointRadius)
        {
            // Move the door towards the closed position at the doorSpeed
            transform.position = Vector2.MoveTowards(transform.position, closePoint.position, doorSpeed);
        }

        // Close the door after a set amount of time
        if (isOpen && closeOnTimer)
        {
            doorOpenTime += Time.deltaTime;
            if (doorOpenTime >= timer)
            {
                isOpen = false;
            }
        }
    }


    // Calling this function once will change the door's state and cause it to open or close accordingly.
    public void ToggleDoorState()
    {
        Debug.Log("Event triggered");
        isOpen = !isOpen;
        doorOpenTime = 0;
    }
}
