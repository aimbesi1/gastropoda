using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public Gun gun;
    public sword sword;

    public Transform holdposition;

    public void getGun()
    {
        Instantiate(gun, holdposition.position, holdposition.rotation);
    }

    public void getSword()
    {
        Instantiate(sword, holdposition.position, sword.transform.rotation);
    }

}
