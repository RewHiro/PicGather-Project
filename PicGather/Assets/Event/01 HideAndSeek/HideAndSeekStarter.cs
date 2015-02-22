using UnityEngine;
using System.Collections;

public class HideAndSeekStarter : EventStarterBase
{
    Sun sun;

    // Use this for initialization
    void Start()
    {
        GetManager();
        sun = GameObject.Find("FrotnSun").GetComponent<Sun>();
    }

    // Update is called once per frame
    void Update()
    {
        StartJudgmentUpdate();

        if (!sun.isHit) return;
        if (!Judgment()) return;
        BeginEvent();
    }

    /// <summary>
    /// イベント開始
    /// </summary>
    protected override void BeginEvent()
    {
        base.BeginEvent();

        CanStart = false;
        EventMngr.BeginEvent(OriginEventPrefab);
    }
}
