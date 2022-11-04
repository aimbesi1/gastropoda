using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject theGun;
    public GameObject theSword;
    public GameObject theSaltGun;

    public GameObject gun_Image;
    public GameObject gun_Border;
    public GameObject sword_Image;
    public GameObject sword_Border;
    public GameObject salt_Image;
    public GameObject salt_Border;

    public bool has_gun = false;
    public bool has_sword = false;
    public bool has_saltgun = false;

    public int num_clip = 0;

    private int weaponSelection = 0;

    // Give the player a weapon and assign a reference to that weapon's spawner.
    public void getGun()
    {
        if (theSword.gameObject.activeSelf)
        {
            theSword.gameObject.SetActive(false);
            sword_Border.SetActive(false);
        }
        if(theSaltGun.gameObject.activeSelf)
        {
            theSaltGun.gameObject.SetActive(false);
            salt_Border.SetActive(false);
        }
        theGun.gameObject.SetActive(true);
        gun_Image.SetActive(true);
        gun_Border.SetActive(true);
        has_gun = true;
        //theGun.SetSpawner(spawner);
    }

    public void getSaltGun()
    {
        if (theSword.gameObject.activeSelf)
        {
            theSword.gameObject.SetActive(false);
            sword_Border.SetActive(false);
        }
        if(theGun.gameObject.activeSelf)
        {
            theGun.gameObject.SetActive(false);
            gun_Border.SetActive(false);
        }
        theSaltGun.gameObject.SetActive(true);
        salt_Image.SetActive(true);
        salt_Border.SetActive(true);
        has_saltgun = true;
        //theSaltGun.SetSpawner(spawner);
    }

    public void storeClip()
    {
        theGun.GetComponent<Gun>().addClip();

    }

    // Similar to getGun
    public void getSword()
    {
        if (theGun.gameObject.activeSelf)
        {
            theGun.gameObject.SetActive(false);
            gun_Border.SetActive(false);
        }
        if(theSaltGun.gameObject.activeSelf)
        {
            theSaltGun.gameObject.SetActive(false);
            salt_Border.SetActive(false);
        }
        theSword.gameObject.SetActive(true);
        sword_Image.SetActive(true);
        sword_Border.SetActive(true);
        has_sword = true;
        //theSword.SetSpawner(spawner);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponSelection != 1 && has_gun)
        {
            swapWeapons(1);
            weaponSelection = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weaponSelection != 2 && has_sword)
        {
            swapWeapons(2);
            weaponSelection = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && weaponSelection != 2 && has_saltgun)
        {
            swapWeapons(3);
            weaponSelection = 3;
        }

    }

    //Player can switch the weapons based on the num 1, 2, 3
    //         1 - Normal Gun
    //         2 - Sword
    //         3 - Salt Gun
    void swapWeapons(int num)
    {
        switch (num)
        {
            case 1:
                theGun.gameObject.SetActive(true);
                gun_Border.SetActive(true);
                theSword.gameObject.SetActive(false);
                sword_Border.SetActive(false);
                theSaltGun.gameObject.SetActive(false);
                salt_Border.SetActive(false);
                break;
            case 2:
                theSword.gameObject.SetActive(true);
                sword_Border.SetActive(true);
                theGun.gameObject.SetActive(false);
                gun_Border.SetActive(false);
                theSaltGun.gameObject.SetActive(false);
                salt_Border.SetActive(false);
                break;
            case 3:
                theSaltGun.gameObject.SetActive(true);
                salt_Border.SetActive(true);
                theSword.gameObject.SetActive(false);
                sword_Border.SetActive(false);
                theGun.gameObject.SetActive(false);
                gun_Border.SetActive(false);
                break;
        }
    }

}
