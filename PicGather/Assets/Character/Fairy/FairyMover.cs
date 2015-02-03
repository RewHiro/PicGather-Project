/// ---------------------------------------------------
/// date ： 2015/01/12    
/// brief ： 妖精の動き処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FairyMover : MonoBehaviour {

    GameObject FeverGauge = null;

    public bool IsMove { get { return (State == STATE.Move); } }

    float Count = 0;

    const float ArrivalTime = 3.0f;
    const float StandbyTime = 5.0f;

    enum STATE
    {
        Stop,
        Move,
        Absorption,
    };
    STATE State = STATE.Stop;


	// Use this for initialization
	void Start () {
        FeverGauge = GameObject.Find("FeverGauge");
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
        Arrival();
        MoveToFerveGauge();
	}

    /// <summary>
    /// 移動処理
    /// 木をタップしたらそこに向かって移動していく
    /// </summary>
    void Move()
    {
        if (State != STATE.Stop) return;
        
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

        State = STATE.Move;
    }

    /// <summary>
    /// 到着時間に来たら状態が止まるにする
    /// </summary>
    void Arrival()
    {
        if (State != STATE.Move) return;

        Count += Time.deltaTime;
        if(Count >= ArrivalTime)
        {
            Count = 0;
            State = STATE.Stop;
        }
    }

    /// <summary>
    /// 吸収状態に設定する
    /// </summary>
    public void SetStateAbsorption()
    {
        State = STATE.Absorption;
    }

    /// <summary>
    /// フィーバーゲージに向かって移動
    /// </summary>
    void MoveToFerveGauge()
    {
        if (State != STATE.Absorption) return;

        iTween.MoveTo(gameObject, iTween.Hash("position", FeverGauge.transform.position,
                        "time", ArrivalTime, "easetype", iTween.EaseType.easeInOutExpo));
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == FeverGauge.name)
        {
            var value = gameObject.transform.localScale.x;
            FeverGauge.GetComponent<FeverManager>().AddScore(value);
            Destroy(gameObject);
        }
    }
}
