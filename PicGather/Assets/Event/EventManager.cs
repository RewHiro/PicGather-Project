﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    /// <summary>
    /// イベントを起こす際に必要になる情報
    /// </summary>
    public struct EventInfo
    {
        /// <summary>
        /// 発生させるイベント
        /// </summary>
        public GameObject PlayingEvent;

        /// <summary>
        /// イベントを開始するフレームならtrue
        /// </summary>
        public bool BeginEvent;

        /// <summary>
        /// 現在イベント中かどうかを判断する
        /// </summary>
        public bool NowPlayingEvent;
    }

    /// <summary>
    /// イベントの情報を統括するメンバ変数
    /// </summary>
    public EventInfo EventInformation = new EventInfo();

    void Start()
    {
        EventInformation.BeginEvent = false;
        EventInformation.NowPlayingEvent = false;
    }

	// Update is called once per frame
	void Update () {
        if(EventInformation.BeginEvent)
        {
            Instantiate(EventInformation.PlayingEvent);
            EventInformation.NowPlayingEvent = true;

            EventInformation.BeginEvent = false;

            UIEnabled.Unavailable();
        }
	}

    /// <summary>
    /// 外部からイベントを開始させる
    /// </summary>
    /// <param name="eventPrefab">開始するイベント</param>
    public void BeginEvent(GameObject eventPrefab)
    {
        /// イベント中なら発生させない
        if (EventInformation.PlayingEvent) return;

        EventInformation.PlayingEvent = eventPrefab;
        EventInformation.BeginEvent = true;
    }

}
