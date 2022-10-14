using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool isClose = true;
    private float timer = 10f;

    void Update()
    {
        if(isOpen) //Check to see if the door is open if yes, the door will auto close over a period of time (5s) 
        {               //else it will wait until the player or the bullet to interact in order to open
            OpenDoor();
            isClose = false;
            timer -= Time.deltaTime;
        }
        if(timer <= 5)
        {
            isOpen = false;
        }
        if(!isClose && !isOpen)
        {
            CloseDoor();
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            isClose = true;
            timer = 10f;
        }
    }

    public void OpenDoor() //Move door up
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }

    public void CloseDoor() //Move door down
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }
}
