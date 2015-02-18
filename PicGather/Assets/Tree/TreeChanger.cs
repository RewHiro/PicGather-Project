﻿/// ---------------------------------------------------
/// date ： 2015/02/14  
/// brief ： 木を切り替える処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeChanger : MonoBehaviour 
{
     
    /// <summary>
    /// 木を切り替えるデータ
    /// </summary>
    [System.Serializable]
    public struct ChangeTreeData
    {
        public ChangeTreeData(GameObject prefab, int feverNumTimes)
        {
            Prefab = prefab;
            FeverNumTimes = feverNumTimes;
        }

        public GameObject Prefab;
        public int FeverNumTimes;
    };

    public bool IsScaling { get { return State == STATE.Scaling; } }

    [SerializeField]
    List<ChangeTreeData> TreeData = new List<ChangeTreeData>();

    [SerializeField]
    FeverManager Fever = null;

    GameObject Tree = null;

    enum STATE
    {
        Normal,
        Change,
        Scaling,
        Destroy,
    };

    STATE State = STATE.Normal;

    int CreateIndex = 0;

    // Use this for initialization
	void Start () {
	}
    
	// Update is called once per frame
	void Update () {
        StartChange();
        ChangeChildren();
        DestroyChildren();
	}

    /// <summary>
    /// 通常の状態に戻す
    /// 
    /// </summary>
    public void ChangeNormalState()
    {
        State = STATE.Normal;
    }

    /// <summary>
    /// 変更開始する
    /// </summary>
    void StartChange()
    {
        if (!ModeManager.IsFerverMode) return;
        if (State != STATE.Normal) return;
        if (CreateIndex >= TreeData.Count) return;

        ChangeJudgment();
    }

    /// <summary>
    /// 切り替えるのかを判断する場所
    /// </summary>
    void ChangeJudgment()
    {
        if (TreeData[CreateIndex].FeverNumTimes != Fever.NumTimes)
        {
            State = STATE.Scaling;
        }
        else
        {
            State = STATE.Change;
            Tree = GameObject.Find("Tree");
        }
    }

    /// <summary>
    /// 子オブジェクトを変更
    /// </summary>
    void ChangeChildren()
    {
        if (ModeManager.IsFerverMode ) return;
        if (State != STATE.Change) return;

        CreateChildren();

    }

    /// <summary>
    /// 子オブジェクトを生成
    /// </summary>
    void CreateChildren()
    {

        var clone = (GameObject)Instantiate(TreeData[CreateIndex].Prefab);

        clone.name = "Tree";
        clone.transform.parent = transform;
        clone.transform.localPosition = clone.transform.position;
        clone.transform.localScale = new Vector3(1, 1, 1);

        CreateIndex++;

        State = STATE.Destroy;
    }


    /// <summary>
    /// 子オブジェクトを削除
    /// </summary>
    void DestroyChildren()
    {
        if (State != STATE.Destroy) return;
    
        StartCoroutine("WaitDestroyChildren");
    }

    /// <summary>
    /// 1フレーム待ってから子オブジェクトを削除
    /// </summary>
    IEnumerator WaitDestroyChildren()
    {
        yield return new WaitForEndOfFrame();

        Destroy(Tree);

        State = STATE.Normal;
    }

}
