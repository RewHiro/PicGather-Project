/// ---------------------------------------------------
/// date ： 2015/01/20 
/// brief ： カメラの座標を変えるコントローラー
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChangeCameraPositionController : MonoBehaviour {

    [SerializeField]
    DrawingCanvasSlider Slider = null;

    [SerializeField]
    List<GameObject> UIObject = new List<GameObject>();

    public Vector3 StartPosition { get; private set; }
    public Quaternion StartRotation { get; private set; }


	// Use this for initialization
	void Start () {
        StartPosition = transform.position;
        StartRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        ChangeDrawingCampus();
        ChangeGameMain();
	}

    /// <summary>
    /// お絵かきをする座標に変える
    /// UIも一緒に描画不可にしている。
    /// </summary>
    void ChangeDrawingCampus()
    {
        if (!Slider.IsOpend()) return;

        transform.position = new Vector3(15000, StartPosition.y, StartPosition.z);

        foreach (var ui in UIObject)
        {
            ui.GetComponent<ChangeDrawUIController>().Unavailable();
        }
    }

    /// <summary>
    /// ゲームメインの画面に変える
    /// </summary>
    void ChangeGameMain()
    {
        if (Slider.IsCloseOnClick())
        {
            StartCoroutine("WaitChangeGameMain");
        }

    }

    /// <summary>
    /// 1秒待ってから下が実行される
    /// ゲームメインにカメラの座標を戻す
    /// 一緒にUIも描画可能にしている。
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitChangeGameMain()
    {
        yield return new WaitForSeconds(1.0f);

        gameObject.transform.position = StartPosition;
        gameObject.transform.rotation = StartRotation;

        foreach (var ui in UIObject)
        {
            ui.GetComponent<ChangeDrawUIController>().Enabled();
        }
    }
}
