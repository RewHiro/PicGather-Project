using UnityEngine;
using System.Collections;

public class ParticleSystemController : MonoBehaviour
{
    
	// Use this for initialization
	void Start () {
        particleSystem.renderer.sortingLayerName = "ParticleSystem";
	}
	
	// Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,particleSystem.startLifetime);
	}
}
