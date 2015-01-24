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
    ModeManager modeManager = null;

    [SerializeField]
    GameObject prefab = null;

    [SerializeField]
    GameObject parent = null;

    [SerializeField]
    GameObject drawingCampus = null;

    [SerializeField]
    GameObject campus = null;

    GameObject characterCanvas = null;
    Vector2 campusSize;

    //　ペイントに必要な制御
    public bool isDraw { get; private set; }    //　true：描画中
    public Color32 lineColor { get; private set; }
    public int lineCount { get; private set; }
    public float lineWidth { get; private set; }
    readonly Vector2 campusOffSet = new Vector2(45, 25);

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
            IsRunOffCampus();
        }
    }

    //　キャンパスからはみ出たら描画を止める
    void IsRunOffCampus()
    {
        if (!isDraw) return;
        var mouse = Input.mousePosition;
        if (!(mouse.x < 0 || campusSize.x - campusOffSet.x < mouse.x
            || mouse.y < 0 || campusSize.y - campusOffSet.y < mouse.y)) return;
        StopLine();

    }

    //　キャンパス内だったら描画する
    void CanDrawLine()
    {
        var mouse = Input.mousePosition;

        if (!(mouse.x > 0 && campusSize.x - campusOffSet.x > mouse.x)) return;
        if (!(mouse.y > 0 && campusSize.y - campusOffSet.y > mouse.y)) return;
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

    public void ChangeColor(GameObject button) { 
        lineColor = button.GetComponent<Image>().color;
        lineWidth = 0.03f;
    }
    public void ChangeLineWidth(float width) { lineWidth = width; }
}
