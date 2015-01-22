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
    List<GameObject> UIObject = new List<GameObject>();

    DrawingCanvasSlider Slider = null;

	// Use this for initialization
	void Start () {
        Slider = GetComponent<DrawingCanvasSlider>();
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

        Camera.main.transform.localPosition = new Vector3(15000, Camera.main.transform.position.y, Camera.main.transform.position.z);

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

        Camera.main.transform.localPosition = new Vector3(0, Camera.main.transform.position.y, Camera.main.transform.position.z);

        foreach (var ui in UIObject)
        {
            ui.GetComponent<ChangeDrawUIController>().Enabled();
        }
    }
}
