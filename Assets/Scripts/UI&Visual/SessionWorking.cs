using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SessionWorking : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timer = 0.0f;
    [Range(0,60)]
    public int seconds;
    [Range(0, 60)]
    public int minutes;
    [Range(0, 60)]
    public int hours;


    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        DisplayTime();
    }

    void DisplayTime()
    {
       if(timer >= 60f)
        {
            minutes = Mathf.FloorToInt(timer/60);
            seconds = Mathf.FloorToInt(timer % 60);
        }
        if (minutes > 60)
        {
            hours = Mathf.FloorToInt(minutes / 60);
            minutes = Mathf.FloorToInt(minutes % 60);
        }if(timer < 60)
        {
            seconds = (int)timer;
        }

        //timerText.text = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
        timerText.text = String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

}
