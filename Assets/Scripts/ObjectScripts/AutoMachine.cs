using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMachine : MonoBehaviour
{
    public bool isTop = false;
    [SerializeField]private int speed = 3;
    [SerializeField]private float timer = 4f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (isTop)
        {
            MoveDown();
        }
        else
        {
            MoveUp();
        }
        if (timer <= 2)
        {
            isTop = true;
        }
        if (timer <= 0)
        {
            isTop = false;
            timer = 4f;
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
}