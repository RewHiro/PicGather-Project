using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//　マウスでペンのように描ける機能・線描画
//
//　FIXME:マウスをゆっくり動かすと線が途切れ、途切れになる。
//
public class Painter : MonoBehaviour {

    //　線描画に必要な情報
    Vector3 oldMousePos = Vector3.zero;
    LineRenderer line = null;
    int lineCount = 0;

    //　一筆制御に必要な情報
    bool isDrew = false;   //　true：描画終了
    PaintManager lineManager;

    Vector2 campusOffSet;
    Vector2 campusSize;
    readonly Vector2 valueAdjustment = new Vector2(3, 8);

    void Start()
    {

        //　線に必要な情報を取得
        lineManager = FindObjectOfType(typeof(PaintManager)) as PaintManager;
        line = GetComponent<LineRenderer>();
        var component = gameObject.GetComponent<LineRenderer>();
        var color = lineManager.lineColor;
        var offset = lineManager.lineCount;
        var width = lineManager.lineWidth;

        //　線の情報を設定
        component.renderer.material.color = color;
        oldMousePos = Input.mousePosition;
        gameObject.renderer.sortingOrder = offset;
        line.SetWidth(width, width);
        line.renderer.sortingLayerName = "Line";
        line.renderer.sortingOrder = offset;

        campusSize = lineManager.campusSize;
        campusOffSet = lineManager.campusOffSet;

    }

    void Update()
    {
        OneStrokeDraw();
        StopDrawing();
    }


    //　一筆描画
    void OneStrokeDraw()
    {
        if (isDrew) return;

        //　マウスの情報を設定
        oldMousePos.z = 1.0f;
        var mousePos = Input.mousePosition;
        mousePos.z = 1.0f;


        //　範囲外に出たら範囲外の位置にポジションをセットする
        if (mousePos.x < 0 + campusOffSet.x)
        {
            mousePos.Set(0 + campusOffSet.x, Input.mousePosition.y, 1.0f);
        }
        else if (campusSize.x - valueAdjustment.x < mousePos.x)
        {
            mousePos.Set(campusSize.x - valueAdjustment.x, Input.mousePosition.y, 1.0f);
        }
        else if (mousePos.y < 0 + campusOffSet.y)
        {
            mousePos.Set(Input.mousePosition.x, 0 + campusOffSet.y, 1.0f);
        }
        else if (campusSize.y - valueAdjustment.y < mousePos.y)
        {
            mousePos.Set(Input.mousePosition.x, campusSize.y - valueAdjustment.y, 1.0f);
        }


        //　ワールド座標に変換
        var oldScreenPos = Camera.main.ScreenToWorldPoint(oldMousePos);
        var nowScreenPos = Camera.main.ScreenToWorldPoint(mousePos);

        lineCount++;

        //　線の頂点情報を設定
        line.SetVertexCount(lineCount + 1);

        line.SetPosition(lineCount - 1, oldScreenPos);
        line.SetPosition(lineCount, nowScreenPos);

        oldMousePos = Input.mousePosition;
    }

    //　描画終了の制御
    void StopDrawing()
    {
        if (isDrew || lineManager.GetComponent<PaintManager>().isDraw) return;
        isDrew = true;
    }
}