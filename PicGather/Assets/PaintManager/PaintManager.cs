using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//
//　一筆生成機能
//
//　HACK:フラグを用意してペイント機能を制御している->マウスイベントだけで制御する
//
public class PaintManager : MonoBehaviour {

    [SerializeField]
    GameObject prefab;

    //　ペイントに必要な制御
    public bool isDraw { get; private set; }    //　true：描画中
    public Color32 lineColor { get; private set; }
    public int lineCount { get; private set; }

    void Start()
    {
        lineColor = Color.black;
        lineCount = 0;
    }

    void OnMouseDown()
    {
        isDraw = true;
        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    void OnMouseUp()
    {
        lineCount++;
        isDraw = false;
    }

    public void ChangeColor(GameObject button) { lineColor = button.GetComponent<Image>().color; }
}
