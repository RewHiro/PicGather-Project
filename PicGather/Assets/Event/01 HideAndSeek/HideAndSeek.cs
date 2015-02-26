using UnityEngine;
using System.Collections;

public class HideAndSeek : EventBase
{
    [SerializeField]
    GameObject openOurEyes;

    OpenOurEyesMover eventObject;

    FeverManager feverManager;

    // Use this for initialization
    void Start()
    {
        Instantiate(openOurEyes,new Vector3(8.98f,8.44f,-3.9f),Quaternion.identity);
        eventObject = GameObject.Find("OpenOurEyes(Clone)").GetComponent<OpenOurEyesMover>();
        feverManager = GameObject.Find("FeverGauge").GetComponent<FeverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventObject.state != OpenOurEyesMover.State.FOUND) return;
        Finish();
    }

    /// <summary>
    /// 終了時の処理
    /// </summary>
    protected override void Finish()
    {
        feverManager.AddScore(FeverManager.MaxFeverScore);
        base.Finish();

    }
}
