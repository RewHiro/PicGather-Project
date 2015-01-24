using UnityEngine;
using System.Collections;

public class BabbleMover : MonoBehaviour {

    /// <summary>
    /// 移動量の最大値、最小値
    /// </summary>
    private const float MaxMoveValue = 10.0f;
    private const float MinMoveValue = 0.0f;

    /// <summary>
    /// 移動速度をx,yそれぞれの速度
    /// </summary>
    private Vector2 Velocity = new Vector2(MinMoveValue, MinMoveValue);

    // Use this for initialization
    void Start()
    {
        Velocity = new Vector2(Random.Range(-MaxMoveValue, MaxMoveValue), Random.Range(-MaxMoveValue, MaxMoveValue));
    }

    // Update is called once per frame
    void Update()
    {

        ///スクリーン上での座標を得る
        Vector3 positionInScreen = Camera.main.WorldToScreenPoint(this.transform.position);
        positionInScreen.z = 1.2f;

        TouchMover();

        ///速度調整する
        DecreaseMoveSpeed(ref Velocity.x);
        DecreaseMoveSpeed(ref Velocity.y);

        ///スクリーン座標上での位置で確認し、画面端なら跳ね返る
        Velocity.x *= ChangeVelocity(ref positionInScreen.x, Screen.width);
        Velocity.y *= ChangeVelocity(ref positionInScreen.y, Screen.height);

        ///移動処理
        positionInScreen.x += Velocity.x * Time.deltaTime;
        positionInScreen.y += Velocity.y * Time.deltaTime;

        transform.position = Camera.main.ScreenToWorldPoint(positionInScreen);

    }

    /// <summary>
    /// 自動で速度減少させる
    /// </summary>
    /// <param name="index">減少させる変数</param>
    private void DecreaseMoveSpeed(ref float index)
    {
        /// 移動速度の減少すると判断する閾値（いきち）
        const float ThresholdMoveSpeed = 3.0f;
        ///減少量
        const float DecreaseValue = 0.3f;
        if (index > ThresholdMoveSpeed)
        {
            index -= DecreaseValue;
            if (index < ThresholdMoveSpeed) index = ThresholdMoveSpeed;
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
        if (TouchManager.IsMouseButton(this.gameObject))
        {
            Velocity.x = Input.GetAxisRaw("Mouse X") * Screen.width;
            Velocity.y = Input.GetAxisRaw("Mouse Y") * Screen.height;
        }

        if (TouchManager.IsTouching(this.gameObject))
        {
            Velocity.x = Input.GetTouch(0).deltaPosition.x;
            Velocity.y = Input.GetTouch(0).deltaPosition.y;
        }

    }

}
