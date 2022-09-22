using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public Gun gun;

    public Transform holdposition;

    public void getWeapons()
    {
        Instantiate(gun, holdposition.position, holdposition.rotation);
    }

    public void addClip(int num_clip)
    {
        Debug.Log("Weapons called addClip --- Weapons --> Gun.addClip()");
        gun.addClip(num_clip);
    }

}
