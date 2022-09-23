using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private int throw_time = 2;
    private int time_left;

    private float hit_timer = 0.5f;

    private int dmg = 100;

    private bool is_throwing = false;
    private bool can_hit = true;

    public Transform fly_point;
    private GameObject player;
    public Fly_Sword flysword;

    void Start()
    {
        time_left = throw_time;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && can_hit)
        {
            transform.eulerAngles = new Vector3(0,0,-60);
            can_hit = false;
        }
        if(hit_timer > 0)
        {
            hit_timer -= Time.deltaTime;
        }
        if(hit_timer <= 0)
        {
            transform.eulerAngles = new Vector3(0,0,-30);
            can_hit = true;
            hit_timer = 0.5f;
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(flysword, fly_point.position, fly_point.rotation);
        }

        if(time_left <= 0)
        {
            Destroy(gameObject);
        }

        Parent(player);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        GameObject obj = GameObject.FindWithTag("SpawnObj");
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if(snail != null)
        {
            snail.takeDamage(dmg);
            /*
            if(is_throwing)
            {
                time_left--;
            }
            */
        }
        if(obj != null)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
        }
    }

    void Parent(GameObject parent)
    {
        gameObject.transform.parent = parent.transform;
    }

    void deParent()
    {
        gameObject.transform.parent = null;
    }
}
