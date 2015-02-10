using UnityEngine;
using System.Collections;

/// <summary>
/// イベントの動作を決定するスクリプトの継承元
/// </summary>
public class EventBase : MonoBehaviour {

    /// <summary>
    /// イベントの開始時の処理はここに記述してください
    /// </summary>
    void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// イベントの終了時の処理はここに記述してください
    /// </summary>
    protected virtual void Finish()
    {
    }
}
