using UnityEngine;
using System.Collections;

public class LonelyFairyMover : MonoBehaviour {

    /// <summary>
    /// 空に帰るときに発生するパーティクル
    /// </summary>
    [SerializeField]
    private ParticleSystem ParticlePrefab = null;

    /// <summary>
    /// 距離を測定する
    /// </summary>
    private float Distance = 0.0f;

    /// <summary>
    /// 妖精を移動させる際の目標
    /// </summary>
    private Vector3 TargetPosition = new Vector3(0.0f, 0.0f, 0.0f);

    /// <summary>
    /// 妖精を誘導する角度
    /// </summary>
    private float ShakeAngle = 0.0f;


    /// <summary>
    /// 妖精の行動パターン
    /// </summary>
    public enum MoveMode
    {
        ToCamera,
        Animation,
        ToSky,
        OutOfScreen
    }

    /// <summary>
    /// 今の妖精の動いている状態を得る
    /// </summary>
    public MoveMode NowMoveMode{ get; private set;}

	// Use this for initialization
	void Start () {
        NowMoveMode = MoveMode.ToCamera;
	}
	
	// Update is called once per frame
	void Update () {

        switch(NowMoveMode)
        {
            case MoveMode.ToCamera :
                MoveToCamera();
                break;
            case MoveMode.Animation:
                // Do Animation
                Greeting();
                break;
            case MoveMode.ToSky:
            MoveToSky();
                break;
        }
	}

    /// <summary>
    /// 挨拶状態の行動
    /// </summary>
    private void Greeting()
    {
        /// 追記してください
    }

    /// <summary>
    /// カメラに移動しているときに妖精を左右に振る
    /// </summary>
    private void TargetShake()
    {
        var CanShakeDistance = 1.1f;
        if (Distance > CanShakeDistance)
        {
            ShakeAngle += 0.1f;
            TargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2 + Distance * (Mathf.Sin(ShakeAngle) * Screen.width / 3), Screen.height / 2, 1.0f));
        }
        else
        {
            TargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 1.0f));
        }
    }


    /// <summary>
    /// カメラに向かって移動する
    /// </summary>
    private void MoveToCamera()
    {
        Distance = Vector3.Distance(TargetPosition, transform.position);

        TargetShake();

        var CanMoveDistance = 0.01f;

        var MoveVelocity = (TargetPosition - transform.position).normalized * 1.5f;

        transform.position += MoveVelocity * Distance/2 * Time.deltaTime;

        if (Distance < CanMoveDistance)
        {
            /// アニメーションに置き換える事
            ChangeToSky();
        }

    }

    /// <summary>
    /// 行動パターンを空に向かうようにする
    /// </summary>
    private void ChangeToSky()
    {
        NowMoveMode = MoveMode.ToSky;

        TargetPosition = new Vector3(0.0f, transform.position.y, 0.0f);
        
        ShakeAngle = Mathf.Atan2(transform.position.z - TargetPosition.z,
              transform.position.x - TargetPosition.x);
        
        Distance = Vector3.Distance(TargetPosition, transform.position);

        ParticleInstantiate();

    }

    /// <summary>
    /// 空に移動する
    /// </summary>
    private void MoveToSky()
    {
        transform.position = new Vector3(Distance * Mathf.Cos(ShakeAngle),
                                            transform.position.y * 1.0025f,
                                            Distance * Mathf.Sin(ShakeAngle));
        ShakeAngle += 1.5f * Time.deltaTime;
        Distance *= 0.995f;

        if (Camera.main.WorldToScreenPoint(transform.position).y > Screen.height * 1.1f)
        {
            NowMoveMode = MoveMode.OutOfScreen;
        }
    }

    /// <summary>
    /// パーティクルを生成する
    /// </summary>
    private void ParticleInstantiate()
    {
        var clone = (ParticleSystem)Instantiate(ParticlePrefab,transform.position,Quaternion.identity);
        
        clone.transform.parent = transform;
        clone.Play();
    }

}
