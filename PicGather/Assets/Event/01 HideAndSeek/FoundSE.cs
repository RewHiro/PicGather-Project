using UnityEngine;
using System.Collections;

public class FoundSE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (audio.isPlaying) return;
        Destroy(gameObject);
        Destroy(GameObject.Find("Explosion(Clone)"));
	}
}
