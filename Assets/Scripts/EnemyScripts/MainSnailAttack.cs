using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSnailAttack : MonoBehaviour
{

    public GameObject spitball;
    public GameObject orbs;

    public int num_orbs = 5; //number of small orbs shoot out

    public Transform mouth;
    private float cd_time = 1f;
    private bool can_spit = true;        // check if snail can attack

    private bool can_special;  // check if this is a boss room

    private bool special_ready = true; // check if snail can do special attack
    private float special_cd = 3f;

    void Awake()
    {
        if(PlayerPrefs.GetInt("IsBoss") == 0)
        {
            can_special = false;
        }
        else
        {
            can_special = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(can_spit)
        {
            if(can_special && special_ready)
            {
                SpecialAttack();
                special_ready = false;
            }
            else
            {
                NormalAttack();
            }
            can_spit = false;

        }

        if(!can_spit && cd_time > 0)
        {
            cd_time -= Time.deltaTime;
        }
        if(cd_time <= 0)
        {
            can_spit = true;
            cd_time = 1f;
        }

        if(!special_ready && special_cd > 0)
        {
            special_cd -= Time.deltaTime;
        }
        if(special_cd <= 0)
        {
            special_cd = 3f;
        }
    }


    void SpecialAttack()
    {
        for(int i = 0; i < num_orbs; i++)
        {
            Instantiate(orbs, mouth.position, mouth.rotation);
        }
    }

    void NormalAttack()
    {
        Instantiate(spitball, mouth.position, mouth.rotation);
    }
}
