/// ---------------------------------------------------
/// date ： 2015/01/12  
/// brief ： 雲オブジェクトの移動処理 
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

    GameObject TreeObject = null;

    Vector3 CreateRainPos = Vector3.zero;
    Vector3 TreePos = Vector3.zero;
    Vector3 RotationPos = Vector3.zero;

    float Radius = 0.0f;
    float RotationAngle = 0.0f;
    float Count = 0;
    float StartCreateRainTime = 0;
    float RadiusMoveSpeed = 0;
    float RotationSpeed = 0;
    float AppearanceSpeed = 0;
    float StopAppearancePosY = 0;
    const float ArrivalTime = 5.0f;

    enum STATE
    {
        Appearance,
        Normal,
        TreeTop,
        CreateRain,
        ReturnNormal,
    };

    STATE State = STATE.Appearance;

    RainCreator RainCreate = null;

    public bool IsReturnlMove { get { return (State == STATE.ReturnNormal); } }

    // Use this for initialization
	void Start () {
        RotationPos.y = Random.Range(14.0f,17.0f);
        StartCreateRainTime = Random.Range(2.0f, 4.0f);
        RadiusMoveSpeed = Random.Range(0.5f, 0.7f);
        RotationSpeed = Random.Range(0.5f, 1.0f);
        StopAppearancePosY = Random.Range(Screen.height / 2, Screen.height / 2 + 200);
        AppearanceSpeed = Random.Range(1, 3);
        RainCreate = GetComponent<RainCreator>();
        TreeObject = GameObject.Find("TreeManager");
	}
	
	void Update () 
    {
        CircleRotation();
        AppearanceMove();
        NormalMove();
        StartTreeTopMove();
        TreeTopMove();
        CreateRainMove();
        ReturnNormalPosition();
    }

    /// <summary>
    /// 円運動移動
    /// </summary>
    void CircleRotation()
    {
        TreePos = TreeObject.transform.position;
        RotationPos.x = TreePos.x + Mathf.Cos(RotationAngle) * Radius;
        RotationPos.z = TreePos.z + Mathf.Sin(RotationAngle) * Radius;

        RotationAngle += RotationSpeed * Time.deltaTime;

    }


    /// <summary>
    /// 登場移動
    /// </summary>
    void AppearanceMove()
    {
        if (State != STATE.Appearance) return;

        transform.position = new Vector3(RotationPos.x, TreePos.y + RotationPos.y, RotationPos.z);
        RotationPos.y -= Time.deltaTime * AppearanceSpeed;

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        RotationControl(screenPos.x);

        if (screenPos.y <= StopAppearancePosY)
        {
            State = STATE.Normal;
        }
    }


    /// <summary>
    /// 木の上に向けて移動中の処理
    /// </summary>
    void TreeTopMove()
    {
        if (State != STATE.TreeTop) return;

        CreateRainPos = new Vector3(RotationPos.x, TreePos.y + RotationPos.y, RotationPos.z);
        transform.position = CreateRainPos;
        RotationPos.y += Time.deltaTime;

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.y >= Screen.height - 100)
        {
            State = STATE.CreateRain;
            RainCreate.StartCreate();
        }
    }

    /// <summary>
    /// 雨を生成しているときの移動処理
    /// </summary>
    void CreateRainMove()
    {
        if (State != STATE.CreateRain) return;

        transform.position = new Vector3(RotationPos.x, CreateRainPos.y, RotationPos.z);

        Radius -= RadiusMoveSpeed * Time.deltaTime;
        
        if (Radius <= 0)
        {
            RainCreate.StopCreate();
            Radius = 0;
            RotationAngle = 0;
            State = STATE.ReturnNormal;
        }
    }

    /// <summary>
    /// 通常状態に戻る
    /// </summary>
    void ReturnNormalPosition()
    {
        if (State != STATE.ReturnNormal) return;

        var NormalPos = new Vector3(RotationPos.x, TreePos.y + RotationPos.y, RotationPos.z);
        transform.position = NormalPos;
        RotationPos.y -= Time.deltaTime * AppearanceSpeed;

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        RotationControl(screenPos.x);

        if (screenPos.y <= 200)
        {
            State = STATE.Normal;
        }
    }


    /// <summary>
    /// 通常の移動
    /// </summary>
    void NormalMove()
    {
        if (State != STATE.Normal) return;

        transform.position = new Vector3(RotationPos.x, TreePos.y + RotationPos.y, RotationPos.z);
    }

    /// <summary>
    /// 木の上に移動する
    /// </summary>
    void StartTreeTopMove()
    {
        if (State != STATE.Normal) return;

        Count += Time.deltaTime;
        if (Count <= StartCreateRainTime) return;

        Count = 0;

        if (ModeManager.IsGameMode)
        {
            var Leafs = GameObject.FindGameObjectsWithTag("Leaf");
            if (Leafs.Length == 0) return;
        }

        State = STATE.TreeTop;
    }


    /// <summary>
    /// 半径を制御
    /// </summary>
    /// <param name="speed"></param>
    void RotationControl(float screenPosX)
    {
        Radius += Time.deltaTime * AppearanceSpeed;

        if (screenPosX <= 150 || screenPosX >= Screen.width - 150)
        {
            State = STATE.Normal;
        }


    }
}
