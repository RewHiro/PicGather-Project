using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraphicEffectController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EffectPrefab = new List<GameObject>();

    GameObject Particles;

    void Start () {
        var index = Random.Range(0, EffectPrefab.Count);

        Particles = (GameObject)Instantiate(EffectPrefab[index], 
            transform.position, EffectPrefab[index].transform.localRotation);

        Particles.transform.parent = transform;

        Particles.particleSystem.renderer.sortingLayerName = "ParticleSystem";
	}
	
	// Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, Particles.particleSystem.startLifetime);
	}
}
