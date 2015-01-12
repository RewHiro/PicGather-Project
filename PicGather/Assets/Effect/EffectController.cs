/// ---------------------------------------------------
/// date ： 2015/01/08    
/// brief ： エフェクトを生成する
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

    [SerializeField]
    private GameObject GraphicEffectPrefab = null;

    [SerializeField]
    private GameObject SoundEffectPrefab = null;

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

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == gameObject.name)
                {
                    return true;
                }
            }
        }
        return false;
    }

	// Update is called once per frame
	void Update () 
    {
        if (TouchManager.IsTouching(this.gameObject) || IsMouseButtonDown())
        {
            Instantiate(GraphicEffectPrefab, this.gameObject.transform.position, Quaternion.identity);
            Instantiate(SoundEffectPrefab, this.gameObject.transform.position, Quaternion.identity);
        }

	}
}
