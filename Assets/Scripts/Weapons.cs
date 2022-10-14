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
    public GameObject saltgun_Image;
    public GameObject saltgun_Border;

    public bool has_gun = false;
    public bool has_sword = false;
    public bool has_salt_gun = false;

    public int num_clip = 0;

    private int weaponSelection = 0;

    public void getGun()
    {
        if(theSword.activeSelf)
        {
            theSword.SetActive(false);
            sword_Border.SetActive(false);
        }
        if(theSaltGun.activeSelf)
        {
            theSaltGun.SetActive(false);
            saltgun_Border.SetActive(false);
        }
        theGun.SetActive(true);
        gun_Image.SetActive(true);
        gun_Border.SetActive(true);
        has_gun = !has_gun;
    }

    public void storeClip()
    {
        theGun.GetComponent<Gun>().addClip();
            
    }

    public void getSword()
    {
        if(theGun.activeSelf)
        {
            theGun.SetActive(false);
            gun_Border.SetActive(false);
        }
        if(theSaltGun.activeSelf)
        {
            theSaltGun.SetActive(false);
            saltgun_Border.SetActive(false);
        }
        theSword.SetActive(true);
        sword_Image.SetActive(true);
        sword_Border.SetActive(true);
        has_sword = !has_sword;
    }

    public void getSaltGun()
    {
        if(theGun.activeSelf)
        {
            theGun.SetActive(false);
            gun_Border.SetActive(false);
        }
        if(theSword.activeSelf)
        {
            theSword.SetActive(false);
            sword_Border.SetActive(false);
        }
        theSaltGun.SetActive(true);
        saltgun_Image.SetActive(true);
        saltgun_Border.SetActive(true);
        has_salt_gun = !has_salt_gun;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && weaponSelection != 1 && has_gun)
        {
            swapWeapons(1);
            weaponSelection = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && weaponSelection != 2 && has_sword)
        {
            swapWeapons(2);
            weaponSelection = 2;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && weaponSelection != 3 && has_salt_gun)
        {
            swapWeapons(3);
            weaponSelection = 3;
        }
    
    }

    void swapWeapons(int num)
    {
        switch(num)
        {
            case 1:
                theGun.SetActive(true);
                gun_Border.SetActive(true);
                theSword.SetActive(false);
                sword_Border.SetActive(false);
                theSaltGun.SetActive(false);
                saltgun_Border.SetActive(false);
                break;
            case 2:
                theSword.SetActive(true);
                sword_Border.SetActive(true);
                theGun.SetActive(false);
                gun_Border.SetActive(false);
                theSaltGun.SetActive(false);
                saltgun_Border.SetActive(false);
                break;
            case 3:
                theSaltGun.SetActive(true);
                saltgun_Border.SetActive(true);
                theGun.SetActive(false);
                gun_Border.SetActive(false);
                theSword.SetActive(false);
                sword_Border.SetActive(false);
                break;


        }
    }

}
