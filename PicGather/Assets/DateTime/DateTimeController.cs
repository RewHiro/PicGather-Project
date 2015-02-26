using UnityEngine;
using System.Collections;
using System;

public class DateTimeController : MonoBehaviour {

    static public DateTime NowTime{get;private set;}

    /// <summary>
    /// 朝
    /// </summary>
    static public bool IsMorning
    {
        get 
        {
            if (NowTime.Hour >= 6 && NowTime.Hour <= 10)
            {
                return true;
            }
            return false;
        }
    }
    

    /// <summary>
    /// お昼
    /// </summary>
    static public bool IsNoon
    {
        get
        {
            if (NowTime.Hour >= 11 && NowTime.Hour <= 15)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 夜
    /// </summary>
    static public bool IsNight
    {
        get
        {
            if (NowTime.Hour >= 16 && NowTime.Hour <= 21)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// お休み中
    /// </summary>
    static public bool IsSleep
    {
        get
        {
            if (NowTime.Hour >= 22 && NowTime.Hour <= 5)
            {
                return true;
            }
            return false;
        }
    }
	// Use this for initialization
	void Awake () {
        NowTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
        NowTime = DateTime.Now;

	}



}
