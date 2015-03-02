using UnityEngine;
using System.Collections;

public class StampGestureManager : MonoBehaviour {


    /// <summary>
    /// 葉っぱの数を覚える
    /// </summary>
    public int LeafNumber {get;private set;}

    /// <summary>
    /// スタンプを押す状態かどうか
    /// </summary>
    public bool EnableImage {get;private set;}

    void Start()
    {
        EnableImage = false;
    }

    /// <summary>
    /// 葉の数を記憶する
    /// </summary>
    public void SetLeafNumber()
    {
        FindObjectOfType<StampGestureManager>().LeafNumber = GameObject.FindGameObjectsWithTag("Leaf").Length;
    }

    /// <summary>
    /// スタンプモードかどうかを設定する
    /// </summary>
    /// <param name="isStampMode">スタンプを押す状態...true 押す状態じゃない...false</param>
    public void ChangeStampState(bool isStampMode)
    {
        FindObjectOfType<StampGestureManager>().EnableImage = isStampMode;
    }
}
