/// --------------------------------------------------------------------
/// date ： 2015/01/30  
/// brief ： 葉っぱを生成
/// author ： Yamada Masamistu
/// --------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeafCreator : MonoBehaviour {

    [SerializeField]
    GameObject LeafPrefab = null;

    [SerializeField]
    GameObject TreeObject = null;

    [SerializeField]
    StampListMover StampList = null;

    LeafStampManagerController Manager = null;

    Vector3 BeforeLeafObjectPos = Vector3.zero;
    Texture SelectTexture = null;

    int TextureID = 0;

    const float CanInstanceDistance = 0.5f;

	// Use this for initialization
	void Start () {
        SelectTexture = renderer.material.mainTexture;
        Manager = GetComponent<LeafStampManagerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!ModeManager.IsGameMode) return;
        if (!StampList.IsCreate) return;

        if (TouchManager.IsTouching(TreeObject) || TouchManager.IsMouseButton(TreeObject))
        {
            CreatePrefab();
        }
	}

    /// <summary>
    /// PrefabをGameObjectとして生成する
    /// </summary>
    void CreatePrefab()
    {
        var distance = Vector3.Distance(BeforeLeafObjectPos, TouchManager.TapPos);
        if (distance >= CanInstanceDistance)
        {
            var leafClone = (GameObject)Instantiate(LeafPrefab, TouchManager.TapPos, Quaternion.identity);
            leafClone.transform.parent = gameObject.transform;
            leafClone.gameObject.name = LeafPrefab.gameObject.name;
            leafClone.renderer.material.mainTexture = SelectTexture;
            leafClone.GetComponent<CharacterDataSave>().SetSaveData(TextureID);
            
            Manager.CreateChildrenDataSave(leafClone, TextureID);

            BeforeLeafObjectPos = TouchManager.TapPos;

            Manager.ChildrensDataSave();
        }
    }

    /// <summary>
    /// 選択テクスチャを切り替える
    /// </summary>
    /// <param name="button"></param>
    public void ChangeSelectTexture(GameObject button)
    {
        TextureID = button.GetComponent<LeafIDSetting>().ID;
        SelectTexture = button.GetComponent<Image>().mainTexture;
    }
}
