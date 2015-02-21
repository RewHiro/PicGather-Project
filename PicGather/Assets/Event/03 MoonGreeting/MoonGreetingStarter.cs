using UnityEngine;
using System.Collections;

public class MoonGreetingStarter : EventStarterBase
{

    bool IsNextStart = true;

    // Use this for initialization
    void Start()
    {
        EventMngr = GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {

        /*イベントの開始条件*/
        //      if()
        BeginEvent();

        if (DateTimeController.NowTime.Hour == StartTime + 1)
        {
            IsNextStart = true;
        }
    }

    /// <summary>
    /// イベント開始
    /// </summary>
    protected override void BeginEvent()
    {
        base.BeginEvent();

        ///イベントの発生条件を書く
        if (!IsNextStart) return;
        if (!(DateTimeController.NowTime.Hour == StartTime)) return;

        EventMngr.BeginEvent(OriginEventPrefab);
        IsNextStart = false;
    }
}
