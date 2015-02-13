using UnityEngine;
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
    public EventInfo EventInfomation = new EventInfo();

    void Start()
    {
        EventInfomation.BeginEvent = false;
        EventInfomation.NowPlayingEvent = false;
    }

	// Update is called once per frame
	void Update () {
        if(EventInfomation.BeginEvent)
        {
            Instantiate(EventInfomation.PlayingEvent);
            EventInfomation.NowPlayingEvent = true;

            EventInfomation.BeginEvent = false;
        }
	}

    /// <summary>
    /// 外部からイベントを開始させる
    /// </summary>
    /// <param name="eventPrefab">開始するイベント</param>
    public void BeginEvent(GameObject eventPrefab)
    {
        /// イベント中なら発生させない
        if (EventInfomation.PlayingEvent) return;

        EventInfomation.PlayingEvent = eventPrefab;
        EventInfomation.BeginEvent = true;
    }

}
