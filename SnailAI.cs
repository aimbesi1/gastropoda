using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAI : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rigidbody2D;
    public float speed = 0;

    private float distance;

    //Snail will get faster with increments
    public float increaseSpeedTimer = 5f; // After a set timer of seconds
    public float speedToIncreaseBy = 1f;  // Increase the snail speed by this

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); //When snail spawns, it will find the player
        InvokeRepeating("DoTimer", 0.001f, increaseSpeedTimer);
    }

    private void DoTimer()
    {
        gameObject.SendMessage("IncreaseSpeed", speedToIncreaseBy);
    }

    private void IncreaseSpeed(float s)
    {
        speed += s;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed *Time.deltaTime);
    }
}
