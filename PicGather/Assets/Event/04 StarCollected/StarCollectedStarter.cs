using UnityEngine;
using System.Collections;
using System;

public class StarCollectedStarter : EventStarterBase
{
    [SerializeField]
    GameObject brightStarPrefab;

    GameObject brightStar = null;

    // Use this for initialization
    void Start()
    {
        EventMngr = GetComponent<EventManager>();

        //if (!DateTimeController.IsNight) return;
        brightStar = Instantiate(brightStarPrefab) as GameObject;
        
    }

    // Update is called once per frame
    void Update()
    {

        /*イベントの開始条件*/
        //      if()
        CrateBrightStar();
        EventStart();
    }


    void CrateBrightStar()
    {
        if (DateTimeController.NowTime.Hour != 16) return;
        if (brightStar) return;

        brightStar = Instantiate(brightStarPrefab) as GameObject;
    }
    /// <summary>
    /// イベント開始条件
    /// </summary>
    void EventStart()
    {
        if (!brightStar) return;

        BeginEvent();
    }

    /// <summary>
    /// イベント開始
    /// </summary>
    protected override void BeginEvent()
    {
        base.BeginEvent();

        ///イベントの発生条件を書く
        if (TouchManager.IsMouseButtonDown(brightStar) || TouchManager.IsTouching(brightStar))
        {
            EventMngr.BeginEvent(OriginEventPrefab);
        }
    }
}
