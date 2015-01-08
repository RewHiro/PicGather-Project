using UnityEngine;
using System.Collections;

public class SortingLayerSetting : MonoBehaviour {

    [SerializeField]
    private GameObject SkyDomeObject = null;

	// Use this for initialization
	void Start () {
        SkyDomeObject.renderer.sortingLayerName = "BackGround";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
