using UnityEngine;
using System.Collections;

public class ParticleSystemLayerSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
        particleSystem.renderer.sortingLayerName = "ParticleSystem";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
