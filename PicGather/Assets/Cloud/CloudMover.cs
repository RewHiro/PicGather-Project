/// ---------------------------------------------------
/// date ： 2015/01/12  
/// brief ： 雲オブジェクトの移動処理 / ビルボード処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

    [SerializeField]
    private GameObject TreeObject = null;

    Vector3 CreateRainPos = Vector3.zero;
    Vector3 TreePos = Vector3.zero;
    Vector3 RotationPos = Vector3.zero;

    float Radius = 0.0f;
    float RotationAngle = 0.0f;
    float Count = 0;

    const float ArrivalTime = 5.0f;
    const float StartCreateRainTime = 4.0f;
    const float RotationSpeed = 1.0f;
    const float RadiusMoveSpeed = 0.5f;

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

    // Use this for initialization
	void Start () {
        State = STATE.Normal;
        Radius = Random.Range(8, 9);
        RotationPos.y = Random.Range(5, 7);
        RainCreate = GetComponent<RainCreator>();

	}
	
	void Update () 
    {
        CircleRotation();
        StartLeafTopMove();
        TreeTopMove();
        CreateRainMove();
        ReturnNormalPosition();

        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back);

        transform.rotation *= Quaternion.Euler(0, 180, 0);

    }

    /// <summary>
    /// 木の上に向けて移動中の処理
    /// </summary>
    void TreeTopMove()
    {
        if (State != STATE.TreeTop) return;

        CreateRainPos = new Vector3(RotationPos.x, TreePos.y + RotationPos.y, RotationPos.z);
        transform.localPosition = CreateRainPos;
        RotationPos.y += Time.deltaTime;
        if (RotationPos.y >= 9)
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

        transform.localPosition = NormalPos;

        RotationPos.y -= Time.deltaTime;
        Radius += RadiusMoveSpeed * 4 * Time.deltaTime;

        if (Radius >= 7 || RotationPos.y <= TreePos.y)
        {
            State = STATE.Normal;
        }

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

        if (State != STATE.Normal) return;

        transform.position = new Vector3(RotationPos.x, TreePos.y + RotationPos.y, RotationPos.z);
    }

    /// <summary>
    /// 葉っぱの上に移動する
    /// </summary>
    void StartLeafTopMove()
    {
        if (State != STATE.Normal) return;

        Count += Time.deltaTime;
        if (Count <= StartCreateRainTime) return;

        GameObject[] Leafs = GameObject.FindGameObjectsWithTag("Leaf");
        if (Leafs.Length == 0) return;

        Count = 0;
        State = STATE.TreeTop;
    }
}
