using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMachine : MonoBehaviour
{
    public bool isTop = false;
    private int speed = 3;
    private float timer = 6f;

    void Update()
    {
        timer -= Time.deltaTime;
        if(isTop) //check to see if the machine reach its max height, if not move the machine up else move the machine down
        {
            MoveDown();
        }
        else
        {
            MoveUp();
        }
        if(timer <= 3) //Time for the machine to reach top
        {
            isTop = true;
        }
        if(timer <= 0) //Time for the machine to reach bottom
        {
            isTop = false;
            timer = 6f;
        }
    }

    public void MoveUp() //Move the machine up
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void MoveDown() //Move the machine down
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
