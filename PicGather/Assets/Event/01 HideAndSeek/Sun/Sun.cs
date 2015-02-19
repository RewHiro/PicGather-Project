using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

    public bool isHit { get; private set; }

	// Use this for initialization
	void Start () {
        isHit = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!TouchManager.IsMouseButtonDown(gameObject)) return;
        isHit = true;
	}
}
