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

	// Update is called once per frame
	void Update () 
    {
        if (TouchManager.IsTouching(this.gameObject) || TouchManager.IsMouseButtonDown(this.gameObject))
        {
            Instantiate(GraphicEffectPrefab, this.gameObject.transform.position, Quaternion.identity);
            Instantiate(SoundEffectPrefab, this.gameObject.transform.position, Quaternion.identity);
        }

	}
}
