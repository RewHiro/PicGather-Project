/// ---------------------------------------------------
/// date ： 2015/01/25 
/// brief ： シャボン玉のMeshの描画のコントローラー
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class BabbleRendererController : MonoBehaviour {

    [SerializeField]
    DrawingCanvasSlider Slider = null;

    MeshRenderer Renderer = null;

	// Use this for initialization
	void Start () {
	    Renderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ModeManager.IsDrawingMode())
        {
            Renderer.enabled = false;
        }
        Enabled();
	}

    /// <summary>
    /// お絵かきモードのCloseボタンを押したら、描画可能にする。
    /// </summary>
    void Enabled()
    {
        if (Slider.IsCloseOnClick())
        {
            StartCoroutine("WaitEnabled");
        }

    }

    /// <summary>
    /// 少し待ってから描画可能にする。
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitEnabled()
    {
        yield return new WaitForSeconds(0.5f);

        Renderer.enabled = true;
    }
}
