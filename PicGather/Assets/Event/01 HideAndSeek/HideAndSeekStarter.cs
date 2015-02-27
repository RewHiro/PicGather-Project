using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HideAndSeekStarter : EventStarterBase
{

    bool isStart = false;

    // Use this for initialization
    void Start()
    {
        GetManager();
    }

    // Update is called once per frame
    void Update()
    {
        StartJudgmentUpdate();

        if (!isStart) return;
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
        isStart = false;
        GameObject.Find("SunCharacter").GetComponent<Image>().enabled = false;
    }

    public void OnSunButton()
    {
        isStart = true;
    }
}
