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

    Vector3 TapPos = Vector3.zero;


	// Use this for initialization
	void Start () {
	
	}
    /// <summary>
    /// デバックで使用
    /// マウス左ボタンが押されたときの処理
    /// Rayを飛ばして当たってたら、trueを返す
    /// </summary>
    /// <returns>当たったかどうか?の判定</returns>
    bool IsMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if(IsRayCatsHit(ray,hit))
            {
                return true;
            }
        }
        return false;
    }


    /// <summary>
    /// RayCastで当たったかどうかの判定
    /// タップした座標を取得する。
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="hit"></param>
    /// <returns>当たったかどうか</returns>
    bool IsRayCatsHit(Ray ray,RaycastHit hit)
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "Tree")
            {
                TapPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                return true;
            }
        }
        return false;
    }

	void Update () {
        if (IsMouseButtonDown())
        {
            Instantiate(LeafPrefab, TapPos, Quaternion.identity);
        }
	}
}
