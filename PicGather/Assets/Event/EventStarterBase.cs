using UnityEngine;
using System.Collections;

/// <summary>
/// イベントのスタートを管理するスクリプトの継承元
/// </summary>
public class EventStarterBase : MonoBehaviour {


    [SerializeField]
    [Range(6, 20)]
    protected int StartTime = 0;

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
	void Start () {
        EventMngr = GetComponent<EventManager>();
	}
	
	// Update is called once per frame
	void Update () {

    }

  
    /// <summary>
    /// イベントを開始する
    /// </summary>
    protected virtual void BeginEvent()
    {
    }
}
