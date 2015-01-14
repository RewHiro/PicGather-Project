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

    FairyManagerController Manager = null;

    float Count = 0;
    public bool IsMove{get;private set;}

    const float ArrivalTime = 3.0f;

	// Use this for initialization
	void Start () {
        if (!Manager)
        {
            Manager = FindObjectOfType(typeof(FairyManagerController)) as FairyManagerController;
        }
        IsMove = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!Manager.IsSelect) return;

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

        if (TouchManager.IsTouching(TreeObject) || TouchManager.IsMouseButtonDown(TreeObject))
        {
            SetMoveTo();
        }

        GameObject[] Fruits = GameObject.FindGameObjectsWithTag("Fruit");
        foreach (var fruit in Fruits)
        {
            if (TouchManager.IsTouching(fruit) || TouchManager.IsMouseButtonDown(fruit))
            {
                SetMoveTo();
            }
        }
    }

    /// <summary>
    /// 指定した場所に移動させる様に設定している。
    /// </summary>
    void SetMoveTo()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", TouchManager.TapPos,
                        "time", ArrivalTime, "easetype", iTween.EaseType.easeInOutExpo));
        IsMove = true;
        Count = 0;
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
