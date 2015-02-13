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
    FairyAppear Appear = null;

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
        Appear = GetComponent<FairyAppear>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        StartMove();
        Arrival();
        MoveToFerveGauge();
	}

    /// <summary>
    /// カメラの方向に向く
    /// </summary>
    void CameraForLookAt()
    {
        iTween.LookTo(gameObject, Camera.main.transform.position, ArrivalTime);
    }

    /// <summary>
    /// 移動処理
    /// 木をタップしたらそこに向かって移動していく
    /// </summary>
    void StartMove()
    {
        if (State != STATE.Stop) return;
        if (!Appear.IsStop) return;

        CameraForLookAt();

        Count += Time.deltaTime;
        if (Count >= StandbyTime)
        {
            SetMoveTo();
        }
    }

    /// <summary>
    /// 木の実の番地をランダムで設定。
    /// そこに向かって移動する。
    /// </summary>
    void SetMoveTo()
    {
        var fruits = GameObject.FindGameObjectsWithTag("Fruit");
        if (fruits.Length == 0) return;

        var randomNum = Random.Range(0, fruits.Length);
        var fruitsPos = fruits[randomNum].transform.position;

        iTween.MoveTo(gameObject, iTween.Hash("position", fruitsPos,
                        "time", ArrivalTime, "easetype", iTween.EaseType.easeInOutExpo));

        iTween.LookTo(gameObject, fruitsPos, ArrivalTime);

        State = STATE.Move;
        Count = 0;

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

        var ferverGaugePos = FeverGauge.transform.position;
        iTween.MoveTo(gameObject, iTween.Hash("position", ferverGaugePos,
                        "time", ArrivalTime, "easetype", iTween.EaseType.easeInOutExpo));

        iTween.LookTo(gameObject, ferverGaugePos, ArrivalTime);

    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == FeverGauge.name)
        {
            FerverGaugeHit();
        }
        if (collision.gameObject.name == name)
        {
            SetMoveTo();
        }
    }

    /// <summary>
    /// フィーバーゲージに当たった時の処理
    /// </summary>
    void FerverGaugeHit()
    {
        var value = gameObject.transform.lossyScale.x;
        FeverGauge.GetComponent<FeverManager>().AddScore(value);
        Destroy(gameObject);

        var Manager = GameObject.FindObjectOfType<FairyManagerController>() as FairyManagerController;
        Manager.ChildrensDataSave();

    }
}
