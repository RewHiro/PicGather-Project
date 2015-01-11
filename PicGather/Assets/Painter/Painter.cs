using UnityEngine;
using System.Collections;

//　マウスでペンのように描ける機能
//　線描画
//
//　FIXME:マウスをゆっくり動かすと線が途切れ、途切れになる。
//
public class Painter : MonoBehaviour {

    //　線描画に必要な情報
    Vector3 oldMousePos = Vector3.zero;
    LineRenderer line = null;
    int lineCount = 0;

    //　一筆制御に必要な情報
    bool isDrew  = false;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetWidth(0.01f, 0.01f);
        oldMousePos = Input.mousePosition;
    }

    void Update()
    {
        OneStrokeDraw();
        StopDraw();
    }

    //　一筆描画
    void OneStrokeDraw()
    {
        if (isDrew ) return;

        //　マウスの情報を設定
        oldMousePos.z = 1.0f;
        var mousePos = Input.mousePosition;
        mousePos.z = 1.0f;

        //　
        var oldScreenPos = Camera.main.ScreenToWorldPoint(oldMousePos);
        var nowScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //　線の頂点情報を設定
        line.SetVertexCount(lineCount + 2);
        line.SetPosition(lineCount, oldScreenPos);
        line.SetPosition(lineCount + 1, nowScreenPos);

        lineCount++;
        oldMousePos = Input.mousePosition;
    }

    //　描画終了の制御
    void StopDraw()
    {
        if (isDrew) return;

        GameObject line_mgr = GameObject.Find("PaintManager");
        if (line_mgr.GetComponent<PaintManager>().isDraw) return;
        isDrew  = true;
    }
}
