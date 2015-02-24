﻿/// --------------------------------------------------------------------
/// date ： 2015/02/23  
/// brief ： タイトルスターター
/// author ： Yamada Masamistu
/// --------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TitleStartter : MonoBehaviour {

    [SerializeField]
    float GoalTime = 3.0f;

    [SerializeField]
    float FadeOutTime = 2.0f;

    float Alpha = 0.0f;

    [SerializeField]
    Texture2D BlackTexture;

    [SerializeField]
    FairyTitleMover FairyMover = null;

    public float GetGoalTime { get { return GoalTime; } }
    public bool IsStart {get;private set;}
    public float WindDirection { get; private set; }
	// Use this for initialization
    void Awake()
    {
        var value = Random.Range(0, 100);

        if (value >= 50)
        {
            WindDirection = -20;
        }
        else
        {
            WindDirection = 20;
        }

	}

    void OnGUI()
    {
        GUI.color = new Color(0, 0, 0, Alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackTexture);
    }

    void UpdateHandler(float value)
    {
        Alpha = value;
    }
	
	// Update is called once per frame
	void Update () {
        if (TouchManager.IsPhaseTap || Input.GetMouseButtonDown(0))
        {
            FairyMover.StartAnimation();
        }
        if (Alpha >= 1)
        {
            Application.LoadLevel("GameMain");
        }
	}

    /// <summary>
    /// 移動スタート
    /// </summary>
    public void StartMove()
    {
        if (IsStart) return;

        IsStart = true;
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("MovePath"), "time", GoalTime, "easetype", iTween.EaseType.easeOutSine));
        iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", FadeOutTime, "onupdate", "UpdateHandler"));
    }

}