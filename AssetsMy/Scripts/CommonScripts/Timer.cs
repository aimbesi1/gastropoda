using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    private float time = 0;

    private float mins = 0;
    private float secs = 0;
    private float milsecs;

    void Start()
    {
        time = PlayerPrefs.GetFloat("SpeedRunTime");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        milsecs = time * 1000 % 1000;

        if (secs >= 60)
        {
            mins++;
            secs = 0;
        }
        else
        {
            if (mins > 0)
            {
                secs = Mathf.Round(time) % (60 * mins);
            }
            else
            {
                secs = Mathf.Round(time);
            }

        }
        text.text = string.Format("{0:00}:{1:00}.{2:000}", mins, secs, milsecs);
        PlayerPrefs.SetFloat("SpeedRunTime", time);
    }
}
