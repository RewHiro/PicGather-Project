/// --------------------------------------------------------------------
/// date ： 2015/01/12  
/// brief ： 葉のスタンプ処理。　木の枝をタップしたら生成される
/// author ： Yamada Masamistu
/// --------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeafStampManagerController : CharacterManager {

    [SerializeField]
    GameObject LeafPrefab = null;

    [SerializeField]
    GameObject TreeObject = null;

    [SerializeField]
    float CanInstanceDistance = 0.5f;

    Vector3 BeforeLeafObjectPos = Vector3.zero;

    [SerializeField]
    StampListMover ListMove = null;

    Texture SelectTexture = null;

	// Use this for initialization
	void Start () {
        IsSelect = false;
        SelectTexture = renderer.material.mainTexture;
	}
    
	void Update () 
    {
        if (!IsSelect) return;
            
        CreateLeaf();
	}

    /// <summary>
    /// 葉っぱを生成
    /// </summary>
    void CreateLeaf()
    {
        if (TouchManager.IsTouching(TreeObject) || TouchManager.IsMouseButton(TreeObject))
        {
            float Distance = Vector3.Distance(BeforeLeafObjectPos, TouchManager.TapPos);
            if (Distance >= CanInstanceDistance)
            {
                var LeafClone = (GameObject)Instantiate(LeafPrefab, TouchManager.TapPos, Quaternion.identity);
                LeafClone.gameObject.name = LeafPrefab.gameObject.name;
                LeafClone.renderer.material.mainTexture = SelectTexture;
                BeforeLeafObjectPos = TouchManager.TapPos;
            }
        }
    }

    public void ChangeSelectTexture(GameObject button)
    {
        SelectTexture = button.GetComponent<Image>().mainTexture;
    }

    public override void NonSelect()
    {
        IsSelect = false;
        ListMove.Close();
    }

    public override void SetCanSelect()
    {
        IsSelect = true;
        ListMove.Open();
    }
}
