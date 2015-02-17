/// ---------------------------------------------------
/// date ： 2015/01/08    
/// brief ： SortingLayerを指定する
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using System.Collections;

public class SortingLayerSetting : MonoBehaviour {

    [SerializeField]
    private GameObject SkyDomeObject = null;

    [SerializeField]
    private GameObject FlaskObject = null;

	// Use this for initialization
	void Start () {
        SkyDomeObject.renderer.sortingLayerName = "BackGround";
        FlaskObject.renderer.sortingLayerName = "FerverGauge";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
