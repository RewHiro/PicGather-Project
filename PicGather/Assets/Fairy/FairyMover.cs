/// ---------------------------------------------------
/// date ： 2015/01/12    
/// brief ： 妖精の動き処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FairyMover : MonoBehaviour {

    float Count = 0;
    public bool IsMove{get;private set;}

    const float ArrivalTime = 3.0f;
    const float StandbyTime = 5.0f;

	// Use this for initialization
	void Start () {
        IsMove = false;
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
        
        Count += Time.deltaTime;
        if (Count >= StandbyTime)
        {
            SetMoveTo();
            Count = 0;
        }
    }

    /// <summary>
    /// 木の実の番地をランダムで設定。
    /// そこに向かって移動する。
    /// </summary>
    void SetMoveTo()
    {
        GameObject[] Fruits = GameObject.FindGameObjectsWithTag("Fruit");
        if (Fruits.Length == 0) return;

        var RandomNum = Random.Range(0, Fruits.Length);
        iTween.MoveTo(gameObject, iTween.Hash("position", Fruits[RandomNum].transform.position,
                        "time", ArrivalTime, "easetype", iTween.EaseType.easeInOutExpo));
        IsMove = true;
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
