using UnityEngine;
using System.Collections;

public class HideAndSeekStarter : EventStarterBase
{


    // Use this for initialization
    void Start()
    {
        EventMngr = GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("OK");
        BeginEvent();
    }

    /// <summary>
    /// イベント開始
    /// </summary>
    protected override void BeginEvent()
    {
        base.BeginEvent();

        ///イベントの発生条件を書く

        EventMngr.BeginEvent(OriginEventPrefab);
    }
}
