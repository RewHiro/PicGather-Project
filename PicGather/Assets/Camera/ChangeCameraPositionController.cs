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

    Vector3 OriginPosition = Vector3.zero;
    Quaternion OriginRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
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

        OriginPosition = transform.position;
        OriginRotation = transform.rotation;
        transform.position = new Vector3(15000, OriginPosition.y, OriginPosition.z);

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

        gameObject.transform.position = OriginPosition;
        gameObject.transform.rotation = OriginRotation;
    }
}
