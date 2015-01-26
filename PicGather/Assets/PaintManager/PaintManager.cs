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
    GameObject prefab = null;

    [SerializeField]
    GameObject parent = null;

    [SerializeField]
    GameObject drawingCampus = null;

    [SerializeField]
    GameObject campus = null;

    GameObject characterCanvas = null;
    public Vector2 campusSize;

    //　ペイントに必要な制御
    public bool isDraw { get; private set; }    //　true：描画中
    public Color lineColor { get; private set; }
    public int lineCount { get; private set; }
    public float lineWidth { get; private set; }
    public readonly Vector2 valueAdjustment = new Vector2(3, 8);
    public readonly Vector2 campusOffSet = new Vector2(34 + 5, 22 + 8);


    void Start()
    {
        lineColor = Color.black;
        lineCount = 1;
        lineWidth = 0.03f;
        campusSize = campus.GetComponent<RectTransform>().rect.size;

    }

    void Update()
    {
        if (!ModeManager.IsDrawingMode()) return;

        if (Input.GetMouseButtonDown(0))
        {
            CanDrawLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopLine();
        }
        if (Input.GetMouseButton(0))
        {
            UpdateBeyondCampus();
        }
    }

    /// <summary>
    /// 範囲にでたら描画をやめる、範囲に入ったら描画する
    /// </summary>
    void UpdateBeyondCampus()
    {
        StartDraw();
        StopDraw();
    }


    /// <summary>
    /// 描画を始める
    /// </summary>
    void StartDraw()
    {
        if (isDraw) return;
        var mouse = Input.mousePosition;
        if (!(mouse.x > 0 + campusOffSet.x && campusSize.x - valueAdjustment.x > mouse.x
                && mouse.y > 0 + campusOffSet.y && campusSize.y - valueAdjustment.y > mouse.y)) return;
        CanDrawLine();
    }

    /// <summary>
    /// 描画を止める
    /// </summary>
    void StopDraw()
    {
        if (!isDraw) return;
        var mouse = Input.mousePosition;
        if (!(mouse.x < 0 + campusOffSet.x || campusSize.x - valueAdjustment.x < mouse.x
            || mouse.y < 0 + campusOffSet.y || campusSize.y - valueAdjustment.y < mouse.y)) return;
        StopLine();
    }

    //　キャンパス内だったら描画する
    void CanDrawLine()
    {
        var mouse = Input.mousePosition;

        if (!(mouse.x > 0 + campusOffSet.x && campusSize.x - valueAdjustment.x > mouse.x)) return;
        if (!(mouse.y > 0 + campusOffSet.y && campusSize.y - valueAdjustment.y > mouse.y)) return;
        CreateLine();
    }



    void CreateLine()
    {
        isDraw = true;

        var originPos = Vector3.zero;
        if (!characterCanvas)
        {
            characterCanvas = (GameObject)Instantiate(parent, originPos, Quaternion.identity);
            characterCanvas.transform.parent = drawingCampus.transform;
            characterCanvas.name = parent.name;
        }

        var Clone = (GameObject)Instantiate(prefab, originPos, Quaternion.identity);

        Clone.name = prefab.name;
        Clone.transform.parent = characterCanvas.transform;
    }


    void StopLine()
    {
        lineCount++;
        isDraw = false;
    }

    /// <summary>
    /// lineの初期化
    /// </summary>
    public void InitLine()
    {
        StartCoroutine("WaitInitLine");
    }

    /// <summary>
    /// lineを初期化するWait関数
    /// 1秒待って下の処理が実行させる
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitInitLine()
    {
        yield return new WaitForSeconds(1.0f);

        lineCount = 1;
        isDraw = false;
        lineColor = Color.black;
    }

    public void ChangeColor(Material material)
    {
        lineColor = material.color;
        lineWidth = 0.03f;
    }

    public void ChangeLineWidth(float width) { lineWidth = width; }
}
