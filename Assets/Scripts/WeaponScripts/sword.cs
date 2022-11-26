using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int throw_time = 0;

    private bool can_hit = true;
    public bool is_flying = false;

    private float hit_timer = 1f;
    private float fly_timer = 2f;

    private GameObject player;
    public Transform flyPoint;
    public Fly_Sword flysword;
    public GameObject swingsword;

    //delete this also
    //private Spawner spawn;
    private PowerUpSpawner spawner;

    public Weapons weapons;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && can_hit && !is_flying)       // Swing the sword if pressed right mouse
        {
            GetComponent<Renderer>().enabled = false;
            swingsword.SetActive(true);
            can_hit = !can_hit;
        }
        if(hit_timer > 0 && !can_hit)               // Animation stuff by fixing the rotation
        {
            hit_timer -= Time.deltaTime;
        }
        if(hit_timer <= 0)
        {
            can_hit = !can_hit;
            hit_timer = 1f;
            GetComponent<Renderer>().enabled = true;
            swingsword.SetActive(false);
        }

        else if (Input.GetButtonDown("Fire2") && !is_flying)        // Throw the sword if pressed left mouse
        {
            GetComponent<Renderer>().enabled = false;
            Instantiate(flysword, flyPoint.position, flysword.transform.rotation);
            is_flying = !is_flying;
        }
        if(fly_timer > 0 && is_flying)              // Animation stuff by intializing a horizontal sword
        {
            fly_timer -= Time.deltaTime;
        }
        if(fly_timer <= 0)
        {
            is_flying = !is_flying;
            fly_timer = 2f;
            GetComponent<Renderer>().enabled = true;
            throw_time--;
            PlayerPrefs.SetInt("Throwtime", throw_time);
        }

        if(throw_time <= 0) // If throw time < 0, then destroy the sword
        {
            weapons.DestroySword();
            spawner.sword_limit++;
            throw_time = 2;
            PlayerPrefs.SetInt("Throwtime", throw_time);
        }

        Parent(player);
    }

    void Parent(GameObject parent)
    {
        gameObject.transform.parent = parent.transform;
    }
    public void SetSpawner(PowerUpSpawner s)
    {
        spawner = s;
    }
}
