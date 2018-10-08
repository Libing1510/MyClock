using UnityEngine;
using System.Collections;
using System;
using calendar;

public class TestData : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {




        //ChineseCalendar cc = new ChineseCalendar(System.DateTime.Now);
        
        ChineseCalendar cc = new ChineseCalendar(Convert.ToDateTime("2018/12/5"));
        Debug.Log(cc.ChineseDateString);
        Debug.Log(cc.ChineseTwentyFourDay);
        Debug.Log(cc.AnimalString);
        Debug.Log(cc.Constellation);
        Debug.Log(cc.WeekDayStr);
        Debug.Log(cc.GanZhiDateString);




    }

    // Update is called once per frame
    void Update()
    {

    }
}
