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

    [SerializeField]
    List<ChangeTreeData> TreeData = new List<ChangeTreeData>();

    [SerializeField]
    FeverManager Fever = null;

    GameObject Tree = null;

    int CreateIndex = 0;

    enum STATE
    {
        None,
        Change,
        Destroy,
    };

    STATE State = STATE.None;

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
    /// 変更開始する
    /// </summary>
    void StartChange()
    {
        if (!ModeManager.IsFerverMode) return;
        if (State != STATE.None) return;
        if (CreateIndex >= TreeData.Count) return;

        State = STATE.Change;
        Tree = GameObject.Find("Tree");
    }


    /// <summary>
    /// 子オブジェクトを変更
    /// </summary>
    void ChangeChildren()
    {
        if (ModeManager.IsFerverMode ) return;
        if (State != STATE.Change) return;
        if (TreeData[CreateIndex].FeverNumTimes != Fever.NumTimes) return;

        var clone = (GameObject)Instantiate(TreeData[CreateIndex].Prefab);

        clone.name = "Tree";
        clone.transform.parent = transform;
        clone.transform.localPosition = clone.transform.position;

        Debug.Log(clone.transform.localPosition.y);

        iTween.ScaleTo(clone.gameObject,new Vector3(1,1,1),0);

        CreateIndex++;

        State = STATE.Destroy;
    }

    /// <summary>
    /// 子オブジェクトを削除
    /// </summary>
    void DestroyChildren()
    {
        if (State != STATE.Destroy) return;

        Destroy(Tree);

        State = STATE.None;
    }

}
