/// ---------------------------------------------------
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

    [SerializeField]
    CameraMover CameraMain = null;

    [SerializeField]
    float BroadenValue = 1.0f;

    TreeSE SEPlayer = null;
    GameObject Tree = null;
    TreeSaveDataWriter Writer = null;
    Vector3 LocalPos = Vector3.zero;

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
        SEPlayer = GetComponent<TreeSE>();
        Writer = GetComponent<TreeSaveDataWriter>();
        var Loading = GetComponent<TreeSaveDataLoading>().GetLoadData();
        Tree = GameObject.Find("Tree");

        if (Loading.ID <= -1) return;

        CreateIndex = Loading.ID;
        transform.lossyScale.Set(Loading.Scale.X, Loading.Scale.Y, Loading.Scale.Z);
        CreateChildren();
        BroadenValue *= CreateIndex;
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
        Save();
        CameraMain.BroadenMoveRadius(BroadenValue);
        State = STATE.Normal;

        if (CreateIndex >= 0) return;
        SEPlayer.Play();
    }

    /// <summary>
    /// セーブ
    /// </summary>
    public void Save()
    {
        Writer.Write(CreateIndex - 1, LocalPos);
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

        LocalPos = clone.transform.position;
        
        Save();

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

        ChangeNormalState();

    }

}
