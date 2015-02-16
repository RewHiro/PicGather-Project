using UnityEngine;
using System.Collections;

public class OneMoreFeverStarter : EventStarterBase
{

    FeverManager FeverMngr = null;

    // Use this for initialization
    void Start()
    {
        EventMngr = GetComponent<EventManager>();

        FeverMngr = GameObject.FindObjectOfType<FeverManager>();

    }

    /// <summary>
    /// すでに１度スコアゲージがマックスになったかどうか
    /// </summary>
    private bool IsAlreadyMaxScore = false;

    // Update is called once per frame
    void Update()
    {

        /*イベントの開始条件*/
        /// フィーバーゲージがMAX→MINになった時
        if (FeverMngr.FeverScore == FeverManager.MaxFeverScore) IsAlreadyMaxScore = true;

        if(IsAlreadyMaxScore && FeverMngr.FeverScore == FeverManager.MinFeverScore)
        {
            IsAlreadyMaxScore = false;


            const int MaxRange = 1;
            if(true)
            {
                BeginEvent();
            }
        }   
        
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
