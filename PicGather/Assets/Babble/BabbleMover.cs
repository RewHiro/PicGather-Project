using UnityEngine;
using System.Collections;

public class BabbleMover : MonoBehaviour {

    /// <summary>
    /// 移動量の最大値、最小値
    /// </summary>
    private const float MaxMoveValue = 5.0f;
    private const float MinMoveValue = 0.0f;

    /// <summary>
    /// 移動速度をx,yそれぞれの速度
    /// </summary>
    private Vector2 Velocity = new Vector2(MinMoveValue, MinMoveValue);

    /// <summary>
    /// スクリーン座標を保存するための変数
    /// </summary>
    private Vector3 PositionInScreen = new Vector3(0.0f,0.0f,0.0f);


    // Use this for initialization
    void Start()
    {
        Velocity = new Vector2(Random.Range(-MaxMoveValue, MaxMoveValue), Random.Range(-MaxMoveValue, MaxMoveValue));

        PositionInScreen.z = 1.3f;

    }

    // Update is called once per frame
    void Update()
    {
 
        TouchMover();

        ///速度調整する
        DecreaseMoveSpeed();

        ///スクリーン座標上での位置で確認し、画面端なら跳ね返る
        Velocity.x *= ChangeVelocity(ref PositionInScreen.x, Screen.width);
        Velocity.y *= ChangeVelocity(ref PositionInScreen.y, Screen.height);

        ///移動処理
        PositionInScreen.x += Velocity.x ;
        PositionInScreen.y += Velocity.y ;

        transform.position = Camera.main.ScreenToWorldPoint(PositionInScreen);

    }

    /// <summary>
    /// 自動で速度減少させる
    /// </summary>
    /// <param name="index">減少させる変数</param>
    private void DecreaseMoveSpeed()
    {
        /// 移動速度の減少すると判断する閾値（いきち）
        const float ThresholdMoveSpeed = 3.0f;
        ///減少量
        const float DecreaseValue = 0.95f;

        ///x,yの移動量の合計で減速する判断をする
        float AbsoluteMoveSpeed = Mathf.Sqrt((Velocity.x * Velocity.x) + (Velocity.y * Velocity.y));
        if (AbsoluteMoveSpeed > ThresholdMoveSpeed)
        {
            Velocity *= DecreaseValue;
        }
    }

    /// <summary>
    /// もし画面端ならばMoveSpeedの符号を変える
    /// </summary>
    /// <param name="position">超えているかどうかを見る座標</param>
    /// <param name="maxSize">座標の最大値</param>
    /// <returns>もし超えていれば負の値,超えていなければ正の値を返す。</returns>
    private int ChangeVelocity(ref float position, int maxSize)
    {
        float BabbleRadius = transform.localScale.x * maxSize * 0.3f;

        if (position < 0.0f + BabbleRadius)
        {
            ///一度押し戻す
            position = 0.0f + BabbleRadius + 1;

            return -1;
        }

        if (position > maxSize - BabbleRadius)
        {
            ///一度押し戻す
            position = maxSize - BabbleRadius - 1;

            return -1;
        }

        return 1;
    }

    /// <summary>
    /// タッチとドラッグで移動するようにする関数
    /// </summary>
    private void TouchMover()
    {

        const float ExtendValue = 10.0f;
        if (TouchManager.IsMouseButton(this.gameObject))
        {
            Velocity.x = Input.GetAxisRaw("Mouse X") * ExtendValue;
            Velocity.y = Input.GetAxisRaw("Mouse Y") * ExtendValue;
        }

        if (TouchManager.IsTouching(this.gameObject))
        {
            Velocity.x = Input.GetTouch(0).deltaPosition.x * ExtendValue;
            Velocity.y = Input.GetTouch(0).deltaPosition.y * ExtendValue;
        }

    }

}
