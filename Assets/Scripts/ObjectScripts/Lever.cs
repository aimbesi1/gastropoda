using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This object can cause any action to happen when a player or player bullet touches it.
[Serializable] public class ActivateEvent : UnityEvent { }
public class Lever : MonoBehaviour
{
    public GameObject onSwitch;
    public GameObject offSwitch;
    public bool singleUse = false;
    private bool usable = true;
    [SerializeField] private ActivateEvent m_OnTrigger = new ActivateEvent();
    private bool triggered = false;

    private void Start()
    {
        onSwitch.SetActive(false);
        offSwitch.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Bullet")
            && !triggered && usable)
        {
            // Call the chosen function
            triggered = true;
            if(singleUse)
            {
                triggered = false;
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Bullet")
            && triggered)
        {
            triggered = false;
            onSwitch.SetActive(false);
            offSwitch.SetActive(true);
        }
    }

    private void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.E))
        {
            OnTrigger.Invoke();
            onSwitch.SetActive(true);
            offSwitch.SetActive(false);
        }
    }

    // Choose the object to call a function with and the function itself in the Inspector.
    public ActivateEvent OnTrigger
    {
        get { return m_OnTrigger; }
        set { m_OnTrigger = value; }
    }
}
