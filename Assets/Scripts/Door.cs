using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool isClose = true;
    public float doorTimer = 10f;

    void Update()
    {
        if(isOpen)
        {
            OpenDoor();
            isClose = false;
        }
        if(doorTimer <= 5)
        {
            isOpen = false;
        }
        if(!isClose && !isOpen)
        {
            CloseDoor();
        }
        if(doorTimer <= 0)
        {
            isClose = true;
            doorTimer = 10f;
        }
        doorTimer -= Time.deltaTime;
    }

    public void OpenDoor()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }

    public void CloseDoor()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }
}
