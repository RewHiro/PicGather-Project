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

    GameObject characterCanvas = null;

    //　ペイントに必要な制御
    public bool isDraw { get; private set; }    //　true：描画中
    public Color32 lineColor { get; private set; }
    public int lineCount { get; private set; }

    void Start()
    {
        lineColor = Color.black;
        lineCount = 0;
    }

    void Update()
    {
        if (!modeManager.IsDrawingMode()) return;
 
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopLine();
        }
    }


    void CreateLine()
    {
        isDraw = true;

        var originPos = Vector3.zero;
        if (!characterCanvas)
        {
            characterCanvas = (GameObject)Instantiate(parent, originPos, Quaternion.identity);
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

    public void ChangeColor(GameObject button) { lineColor = button.GetComponent<Image>().color; }
}
