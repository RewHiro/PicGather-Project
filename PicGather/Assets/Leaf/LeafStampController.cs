/// --------------------------------------------------------------------
/// date ： 2015/01/12  
/// brief ： 葉のスタンプ処理。　木の枝をアップしたら生成される
/// author ： Yamada Masamistu
/// --------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class LeafStampController : MonoBehaviour {

    [SerializeField]
    GameObject LeafPrefab = null;

    [SerializeField]
    GameObject TreeObject = null;

	// Use this for initialization
	void Start () {
	
	}
    
	void Update () 
    {
        if (TouchManager.IsTouching(TreeObject))
        {
            Instantiate(LeafPrefab, TouchManager.TapPos, Quaternion.identity);
        }
	}
}
