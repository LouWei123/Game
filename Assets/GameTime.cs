using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

    public Text text;
    public Text text2;
    private float time = 0;
    private float timer = 1f;
    private void Start()
    {
        //text = GetComponent<Text>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1f;
            time++;
            text.text = SecondToHour(time);
            text2.text = text.text;
        }
    }
    public static string SecondToHour(float time)
    {
        StringBuilder str = new StringBuilder();
        int hour = 0;
        int minute = 0;
        int second = 0;
        second = Convert.ToInt32(time);

        if (second > 60)
        {
            minute = second / 60;
            second = second % 60;
        }
        if (minute > 60)
        {
            hour = minute / 60;
            minute = minute % 60;
        }
        if (hour > 0 && hour < 10)
        {
            str.Append("0" + hour);
        }
        else if (hour >= 10)
        {
            str.Append(hour);
        }
        else
        {
            str.Append("00");
        }
        str.Append(":");
        if (minute > 0 && minute < 10)
        {
            str.Append("0" + minute);
        }
        else if (minute >= 10)
        {
            str.Append(minute);
        }
        else
        {
            str.Append("00");
        }
        str.Append(":");
        if (second > 0 && second < 10)
        {
            str.Append("0" + second);
        }
        else if (second >= 10)
        {
            str.Append(second);
        }
        else
        {
            str.Append("00");
        }
        return str.ToString();
    }
}
