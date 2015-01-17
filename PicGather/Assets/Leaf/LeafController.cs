/// ---------------------------------------------------
/// date ： 2015/01/12 
/// brief ： 葉っぱのビルボード化
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class LeafController : MonoBehaviour {

    [SerializeField]
    Color DeadLeafColor = Color.white;

    [SerializeField]
    const float WitherTime = 10.0f;

    [SerializeField]
    GameObject FruitPrefab = null;

    Vector3 SwayVelocity = new Vector3(0, -1, 0);
    float LifeTime = 0;

    enum STATE
    {
        None,
        Live,
        Wither,
        Dead,
    };

    STATE State = STATE.None;

	// Use this for initialization
	void Start () {
        State = STATE.Live;
	}
	
	// Update is called once per frame
	void Update () 
    {
        BillboardSetting();
        WitheringTime();
        Fall();
	}

    /// <summary>
    /// 枯れる状態にする。
    /// </summary>
    void StartWither()
    {
        State = STATE.Wither;
        Decolorization();
    }

    /// <summary>
    /// ビルボード法に描画設定をする。
    /// </summary>
    void BillboardSetting()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back);
        transform.rotation *= Quaternion.Euler(0, 180, 0);
    }

    /// <summary>
    /// 枯葉になっていく時間
    /// </summary>
    void WitheringTime()
    {
        if (State != STATE.Wither) return;

        LifeTime += Time.deltaTime;
        if (LifeTime >= WitherTime)
        {
            State = STATE.Dead;
            var GameClone = (GameObject)Instantiate(FruitPrefab, gameObject.transform.position, Quaternion.identity);
            GameClone.name = FruitPrefab.name;
        }
    }

    /// <summary>
    /// 脱色処理
    /// </summary>
    void Decolorization()
    {
        iTween.ColorTo(gameObject, DeadLeafColor, WitherTime - 2);
    }


    /// <summary>
    /// 枯れ落ちる
    /// 画面から消えたら削除するようにしてあります。
    /// </summary>
    void Fall()
    {
        if (State != STATE.Dead) return;

        transform.Translate(SwayVelocity * Time.deltaTime);

        var screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (screenPos.y <= -100)
        {
            Destroy(gameObject);
        }
    }

}
