using UnityEngine;
using System.Collections;

public class HideAndSeekStarter : EventStarterBase
{
    Sun sun;

    // Use this for initialization
    void Start()
    {
        EventMngr = GetComponent<EventManager>();
        sun = GameObject.Find("FrotnSun").GetComponent<Sun>();
    }

    // Update is called once per frame
    void Update()
    {
        BeginEvent();
    }

    /// <summary>
    /// イベント開始
    /// </summary>
    protected override void BeginEvent()
    {
        base.BeginEvent();

        ///イベントの発生条件を書く
        if (!sun.isHit) return;
        EventMngr.BeginEvent(OriginEventPrefab);
    }
}
