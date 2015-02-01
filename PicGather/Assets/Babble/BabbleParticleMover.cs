using UnityEngine;
using System.Collections;

public class BabbleParticleMover : MonoBehaviour {

    /// <summary>
    /// スクリーン上での座標
    /// </summary>
    private Vector3 PositionInScreen = new Vector3();

	// Use this for initialization
	void Start () {
        PositionInScreen = Camera.main.WorldToScreenPoint(transform.position);
        PositionInScreen.z = 1.3f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.ScreenToWorldPoint(PositionInScreen);
	}
}
