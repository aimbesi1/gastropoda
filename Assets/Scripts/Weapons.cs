using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject theGun;
    public GameObject theSword;

    public bool has_gun = false;
    public bool has_sword = false;

    public int num_clip = 0;

    private int weaponSelection = 0;

    public void getGun()
    {
        if(theSword.activeSelf)
        {
            theSword.SetActive(false);
        }
        theGun.SetActive(true);
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
        }
        theSword.SetActive(true);
        has_sword = !has_sword;
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
    
    }

    void swapWeapons(int num)
    {
        switch(num)
        {
            case 1:
                theGun.SetActive(true);
                theSword.SetActive(false);
                break;
            case 2:
                theSword.SetActive(true);
                theGun.SetActive(false);
                break;
        }
    }

}
