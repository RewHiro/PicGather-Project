/// --------------------------------------------------------------------
/// date ： 2015/01/12  
/// brief ： 葉のスタンプ処理。　木の枝をタップしたら生成される
/// author ： Yamada Masamistu
/// --------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class LeafStampController : MonoBehaviour {

    [SerializeField]
    GameObject LeafPrefab = null;

    [SerializeField]
    GameObject TreeObject = null;

    [SerializeField]
    float CanInstanceDistance = 0.5f;

    Vector3 BeforeLeafObjectPos = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
    
	void Update () 
    {
        if (TouchManager.IsTouching(TreeObject) || TouchManager.IsMouseButton(TreeObject))
        {
            float Distance = Vector3.Distance(BeforeLeafObjectPos, TouchManager.TapPos);
            if (Distance >= CanInstanceDistance)
            {
                var LeafClone = (GameObject)Instantiate(LeafPrefab, TouchManager.TapPos, Quaternion.identity);
                LeafClone.gameObject.name = LeafPrefab.gameObject.name;
                BeforeLeafObjectPos = TouchManager.TapPos;
            }
        }
	}
}
