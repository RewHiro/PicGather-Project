using UnityEngine;
using System.Collections;

public class OneMoreFever : EventBase
{

    /// <summary>
    /// 画面を隠すインスタンスのプレハブ
    /// </summary>
    [SerializeField]
    GameObject CurtainPrefab = null;

    /// <summary>
    /// フィーバーゲージを扱う
    /// </summary>
    FeverManager FeverMngr = null;
    
    /// <summary>
    /// 生成するインスタンスの量
    /// </summary>
    private const int MaxInstantiate = 10;

    /// <summary>
    /// 今生成されてから何秒経っているか
    /// </summary>
    private float NowLifeTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        FeverMngr = GameObject.FindObjectOfType<FeverManager>();

        const float OffsetX = 50;
        const int SegmentNumber = 20;
        Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + OffsetX, Random.Range(0, SegmentNumber) * Screen.height / SegmentNumber, 1.1f));
        for(int i = 0;i < MaxInstantiate;i++)
        {
            Instantiate(CurtainPrefab,
                        Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + OffsetX, Random.Range(0, SegmentNumber) * Screen.height / SegmentNumber, 1.1f + (i * 0.01f))),
                        Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        NowLifeTime += Time.deltaTime;


        var BeginAddScoreTime = 1.0f;
        if (NowLifeTime > BeginAddScoreTime)
        {
            FeverMngr.AddScore(FeverManager.MaxFeverScore);
            Finish();
        }

    }

    /// <summary>
    /// 終了時の処理
    /// </summary>
    protected override void Finish()
    {

        base.Finish();
        UIEnabled.Unavailable();
    }
}
