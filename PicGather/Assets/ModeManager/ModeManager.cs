using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour {

    enum STATE
    {
        Game,
        Drawing,
        Ferver,
    };

    static STATE State = STATE.Game;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// 今ゲームモードなのかどうか
    /// </summary>
    /// <returns></returns>
    public static bool IsGameMode()
    {
        return (State == STATE.Game);
    }

    /// <summary>
    /// 今お絵かきモードなのかどうか
    /// </summary>
    /// <returns></returns>
    public static bool IsDrawingMode()
    {
        return (State == STATE.Drawing);
    }

    /// <summary>
    /// 今フィーバーモードなのかどうか
    /// </summary>
    /// <returns></returns>
    public static bool IsFerverMode()
    {
        return (State == STATE.Ferver);
    }

    /// <summary>
    /// お絵かきモードに切り替える
    /// </summary>
    /// <returns></returns>
    public static void ChangeDrawingMode()
    {
        State = STATE.Drawing;
    }

    /// <summary>
    /// ゲームモードに切り替える
    /// </summary>
    /// <returns></returns>
    public static void ChangeGameMode()
    {
        State = STATE.Game;
    }

    /// <summary>
    /// フィーバーモードに切り替える
    /// </summary>
    /// <returns></returns>
    public static void ChangeFerverMode()
    {
        State = STATE.Ferver;
    }
}
