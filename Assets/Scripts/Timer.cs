using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    private float time = 0;

    private float hours;
    private float mins;
    private float secs;
    private float milsecs;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        milsecs = time * 1000 % 1000;
        secs = Mathf.Round(time);
        mins = Mathf.FloorToInt(time) / 60;
        hours = Mathf.FloorToInt(time) / 360;
        text.text = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", hours, mins, secs, milsecs);
    }
}
