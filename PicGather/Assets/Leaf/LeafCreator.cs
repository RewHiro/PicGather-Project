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

    Vector3 BeforeLeafObjectPos = Vector3.zero;
    Texture SelectTexture = null;

    const float CanInstanceDistance = 0.5f;

	// Use this for initialization
	void Start () {
        SelectTexture = renderer.material.mainTexture;
	
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
        var Distance = Vector3.Distance(BeforeLeafObjectPos, TouchManager.TapPos);
        if (Distance >= CanInstanceDistance)
        {
            var LeafClone = (GameObject)Instantiate(LeafPrefab, TouchManager.TapPos, Quaternion.identity);
            LeafClone.transform.parent = gameObject.transform;
            LeafClone.gameObject.name = LeafPrefab.gameObject.name;
            LeafClone.renderer.material.mainTexture = SelectTexture;
            BeforeLeafObjectPos = TouchManager.TapPos;
        }
    }

    /// <summary>
    /// 選択テクスチャを切り替える
    /// </summary>
    /// <param name="button"></param>
    public void ChangeSelectTexture(GameObject button)
    {
        SelectTexture = button.GetComponent<Image>().mainTexture;
    }
}
