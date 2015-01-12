/// ---------------------------------------------------
/// date ： 2015/01/12    
/// brief ： 妖精の動き処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FairyMover : MonoBehaviour {

    //[SerializeField]
    //List<GameObject> TapObject = new List<GameObject>();

    [SerializeField]
    GameObject TreeObject = null;

    float Count = 0;
    bool IsMove = false;

    const float ArrivalTime = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
        Arrival();
	}

    /// <summary>
    /// 移動処理
    /// 木をタップしたらそこに向かって移動していく
    /// </summary>
    void Move()
    {
        if (IsMove) return;
        if (TouchManager.IsTouching(TreeObject) || TouchManager.IsMouseButton(TreeObject))
        {
            iTween.MoveTo(gameObject, iTween.Hash("position", TouchManager.TapPos,
                            "time", ArrivalTime, "easetype", iTween.EaseType.easeInOutExpo));
            IsMove = true;
            Count = 0;
        }
    }

    /// <summary>
    /// 到着時間に来たら移動フラグをfalseにする
    /// </summary>
    void Arrival()
    {
        if (!IsMove) return;
        Count += Time.deltaTime;
        if(Count >= ArrivalTime)
        {
            Count = 0;
            IsMove = false;
        }
    }
}
