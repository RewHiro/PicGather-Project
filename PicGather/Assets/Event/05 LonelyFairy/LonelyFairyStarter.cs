using UnityEngine;
using System.Collections;

public class LonelyFairyStarter : EventStarterBase
{
    /// <summary>
    /// イベントを開始する時間（24時間表記）
    /// </summary>
    private int BeginTime = 8;

    // Use this for initialization
    void Start()
    {
        EventMngr = GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {

        /*イベントの開始条件*/
        if (IsBeginTiming()) BeginEvent();
    }

    /// <summary>
    /// イベント開始
    /// </summary>
    protected override void BeginEvent()
    {
        base.BeginEvent();

        EventMngr.BeginEvent(OriginEventPrefab);
    }


    /// <summary>
    /// イベント開始のタイミング（時間）かどうかを返す関数
    /// </summary>
    /// <returns>開始する...true 開始しない...false</returns>
    private bool IsBeginTiming()
    {
        if (DateTimeController.NowTime.Hour == BeginTime) return true;

        return false;
    }
}
