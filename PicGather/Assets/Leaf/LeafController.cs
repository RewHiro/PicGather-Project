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

    Vector3 SwayVelocity = new Vector3(0, -1, 0);
    float LifeTime = 0;
    bool IsDead = false;

	// Use this for initialization
	void Start () {
        Decolorization();
	}
	
	// Update is called once per frame
	void Update () 
    {
        BillboardSetting();
        WitheringTime();
        Fall();
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
        if (IsDead) return;

        LifeTime += Time.deltaTime;
        if (LifeTime >= WitherTime)
        {
            IsDead = true;
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
        if (!IsDead) return;

        transform.Translate(SwayVelocity * Time.deltaTime);

        var screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (screenPos.y <= -100)
        {
            Destroy(gameObject);
        }
    }

}
