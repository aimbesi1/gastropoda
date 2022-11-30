using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMachine_Adjustable : MonoBehaviour
{
    public bool isTop = false;
    public bool sideToSide = false;
    public float speed = 3;
    public float timerMax = 6f;
    private float timerStart = 6f;

    void Start()
    {
        timerStart = timerMax;
    }

        void Update()
    {
        timerStart -= Time.deltaTime;
        if(!sideToSide)
        {
            if (isTop)
            {
                MoveDown();
            }
            else
            {
                MoveUp();
            }
        }
        else 
        {
            if (isTop)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
        if (timerStart <= (timerMax / 2))
        {
            isTop = true;
        }
        if (timerStart <= 0)
        {
            isTop = false;
            timerStart = timerMax;
        }
    }

    public void MoveUp()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    public void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
