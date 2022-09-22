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

}
