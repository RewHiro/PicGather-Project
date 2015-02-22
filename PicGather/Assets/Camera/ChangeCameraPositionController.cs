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
    /// </summary>
    void ChangeDrawingCampus()
    {
        if (!Slider.IsOpend()) return;

        transform.position = new Vector3(15000, StartPosition.y, StartPosition.z);

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
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitChangeGameMain()
    {
        yield return new WaitForSeconds(1.0f);

        gameObject.transform.position = StartPosition;
        gameObject.transform.rotation = StartRotation;
    }
}
