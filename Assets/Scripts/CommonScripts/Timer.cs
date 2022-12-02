using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float time;

    private float mins = 0;
    private float secs = 0;
    private float milsecs = 0;

    private float bestmins = 0;
    private float bestsecs = 0;
    private float bestmilsecs = 0;

    public TMP_Text text;

    void Start()
    {
        time = PlayerPrefs.GetFloat("SpeedRunTime");
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "End Game Scene")
        {
            CountTimer(PlayerPrefs.GetFloat("SpeedRunTime"), ref milsecs, ref secs, ref mins);
            CountTimer(PlayerPrefs.GetFloat("BestTime"), ref bestmilsecs, ref bestsecs, ref bestmins);
            text.text = string.Format("Completed Time: {0:00}:{1:00}.{2:000}\nFastest Completed Time: {3:00}:{4:00}.{5:000}", mins, secs, milsecs, bestmins, bestsecs, bestmilsecs);
        }

        else
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

            PlayerPrefs.SetFloat("SpeedRunTime", time);

            if(PlayerPrefs.HasKey("BestTime") && PlayerPrefs.GetFloat("BestTime") > 0f && PlayerPrefs.GetInt("GameComplete") == 1 && PlayerPrefs.GetFloat("BestTime") > PlayerPrefs.GetFloat("SpeedRunTime"))
            {
                PlayerPrefs.SetFloat("BestTime", time);
            }
        }
    }

    void CountTimer(float num, ref float ms, ref float s, ref float m)
    {
        ms = num % 1000;
        s = num/1000 % 60;
        m = num / 60;
        
    }
}
