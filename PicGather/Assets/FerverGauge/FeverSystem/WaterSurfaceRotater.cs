using UnityEngine;
using System.Collections;

public class WaterSurfaceRotater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
	}
}
