using UnityEngine;
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
    public bool isDraw { get; private set; }

    void OnMouseDown()
    {
        isDraw = true;
        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    void OnMouseUp()
    {
        isDraw = false;
    }
}
