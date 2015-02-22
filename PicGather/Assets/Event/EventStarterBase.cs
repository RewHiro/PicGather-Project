using UnityEngine;
using System.Collections;

/// <summary>
/// イベントのスタートを管理するスクリプトの継承元
/// </summary>
public class EventStarterBase : MonoBehaviour {


    [SerializeField]
    [Range(6, 20)]
    protected int StartTime = 0;

    protected bool CanStart = true;

    /// <summary>
    /// クラス固有のイベントを所持する
    /// </summary>
    [SerializeField]
    protected GameObject OriginEventPrefab = null;

    /// <summary>
    /// EventManagerを得る
    /// </summary>
    protected EventManager EventMngr = null;

    // Use this for initialization
    protected void GetManager()
    {
        EventMngr = GetComponent<EventManager>();
	}
	
	// Update is called once per frame
    protected void StartJudgmentUpdate()
    {
        if (DateTimeController.NowTime.Hour == StartTime + 1)
        {
            CanStart = true;
        }
    }

  
    /// <summary>
    /// イベントを開始する
    /// </summary>
    protected virtual void BeginEvent()
    {
    }

    /// <summary>
    /// 開始できるかどうかの判定
    /// </summary>
    /// <returns></returns>
    protected bool Judgment()
    {
        if (CanStart && DateTimeController.NowTime.Hour == StartTime) return true;

        return false;
    }
}
