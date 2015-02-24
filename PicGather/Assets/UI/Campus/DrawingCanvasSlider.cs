/// ---------------------------------------------------
/// date ： 2015/01/20 
/// brief ： お絵かきするキャンパスをスライドさせる
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DrawingCanvasSlider : MonoBehaviour {

    [SerializeField]
    AnimationClip OpenAnimClip = null;

    [SerializeField]
    AnimationClip CloseAnimClip = null;

    [SerializeField]
    CampusTemplateSetting CampusTemplate = null;

    [SerializeField]
    CharacterCampusDestroy CampusDes = null;

    [SerializeField]
    DrawingCampusBackGroundController CampusBackGround = null;

    [SerializeField]
    StampListMover StampList = null;

    [SerializeField]
    UIDrawingModeChanger UIModeChanger = null;

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

        if (!ModeManager.IsDrawingMode) return;
        
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
            ModeManager.ChangeDrawingMode();
            State = STATE.Opend;
        }
    }

    /// <summary>
    /// 閉じたを押したかどうかの判定
    /// </summary>
    /// <returns></returns>
    public bool IsCloseOnClick()
    {
        if (State != STATE.Close) return false;
        return true;
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
        yield return new WaitForSeconds(1.0f);

        CampusBackGround.Enabled();
        CampusTemplate.NonSelect();
        ModeManager.ChangeGameMode();
        CampusDes.Des();
        State = STATE.Stop;
        UIModeChanger.Enable(true);
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
        UIModeChanger.Enable(false);
        StampList.CloseAnimation();
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
