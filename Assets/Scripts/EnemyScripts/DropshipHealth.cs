using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DropshipHealth : MonoBehaviour
{

    private int maxhealth = 1000;
    private int currenthealth;

    public Healthbar healthbar;
    public GameObject canvas;
    public TMP_Text text;

    void Awake()
    {
        if( SceneManager.GetActiveScene().name == "Level 2.4")
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    void Start()
    {
        currenthealth = maxhealth;
        healthbar.setMaxHealth(maxhealth);
        printText();
    }

    void Update()
    {
        if(currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void takeDmg(int dmg)
    {
        currenthealth -= dmg;
        healthbar.setHealth(currenthealth);
        printText();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.GetComponent<CannonBullet>() != null)
        {
            takeDmg(hitInfo.GetComponent<CannonBullet>().dmg);
        }
    }

    void printText()
    {
        text.text = currenthealth + "/" + maxhealth;
    }
}
