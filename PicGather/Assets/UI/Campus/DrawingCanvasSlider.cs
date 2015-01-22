﻿/// ---------------------------------------------------
/// date ： 2015/01/20 
/// brief ： お絵かきするキャンパスをスライドさせる
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using System.Collections;

public class DrawingCanvasSlider : MonoBehaviour {

    [SerializeField]
    AnimationClip OpenAnimClip = null;

    [SerializeField]
    AnimationClip CloseAnimClip = null;

    [SerializeField]
    ModeManager ChangeMode = null;

    [SerializeField]
    CampusTemplateSetting CampusTemplate = null;

    [SerializeField]
    CharacterCampusDestroy CampusDes = null;

    [SerializeField]
    DrawingCampusBackGroundController CampusBackGround = null;

    Animation MoveAnimation = null;

    enum STATE
    {
        Stop,   /// 停止
        Open,   /// 開く
        Opend, /// 開いた
        Close,  /// 閉じる
    };

    STATE State = STATE.Stop;

    // Use this for initialization
    void Start()
    {
        MoveAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        Opening();

        if (!ChangeMode.IsDrawingMode()) return;
        Closed();
    }

    /// <summary>
    /// 開いたかどうかの判定
    /// </summary>
    /// <returns></returns>
    public bool IsOpend()
    {
        if (State == STATE.Opend)
        {
            CampusBackGround.Unavailable();
            State = STATE.Stop;
            return true;
        }
        return false;
    }

    void Opening()
    {
        if (State != STATE.Open) return;
        StartCoroutine("WaitOpend");
    }

    IEnumerator WaitOpend()
    {
        yield return new WaitForSeconds(1.0f);
        if (!MoveAnimation.isPlaying)
        {
            State = STATE.Opend;
            ChangeMode.ChangeDrawingMode();
        }
    }
    /// <summary>
    /// 閉じたを押したかどうかの判定
    /// </summary>
    /// <returns></returns>
    public bool IsCloseOnClick()
    {
        if (State != STATE.Close) return false;
        if (MoveAnimation.isPlaying)
        {
            return true;
        } 
        return false;
    }

    /// <summary>
    /// 閉じたアニメーション終わった時の処理
    /// </summary>
    /// <returns></returns>
    void Closed()
    {
        if (State != STATE.Close) return;
        StartCoroutine("WaitClosed");
    }

    IEnumerator WaitClosed()
    {
        yield return new WaitForSeconds(0.1f);
        CampusBackGround.Enabled();

        yield return new WaitForSeconds(1.0f);
        if (!MoveAnimation.isPlaying)
        {
            CampusTemplate.NonSelect();
            ChangeMode.ChangeGameMode();
            CampusDes.Des();
            State = STATE.Stop;
        }
    }

    /// <summary>
    /// 開くアニメーションの処理
    /// </summary>
    public void Open()
    {
        if (State == STATE.Open) return;
        if (MoveAnimation.isPlaying) return;

        State = STATE.Open;

        MoveAnimation.PlayQueued(OpenAnimClip.name);

    }

    /// <summary>
    /// 閉じるアニメーションの処理
    /// </summary>
    public void Close()
    {
        if (State == STATE.Close) return;
        if (MoveAnimation.isPlaying) return;

        State = STATE.Close;
        MoveAnimation.PlayQueued(CloseAnimClip.name);
    }

    /// <summary>
    /// 閉じるアニメーションの処理
    /// </summary>
    public void SaveClose()
    {
        if (State == STATE.Close) return;
        if (MoveAnimation.isPlaying) return;
        if (!CampusTemplate.IsSelect) return;

        State = STATE.Close;
        MoveAnimation.PlayQueued(CloseAnimClip.name);
    }
}