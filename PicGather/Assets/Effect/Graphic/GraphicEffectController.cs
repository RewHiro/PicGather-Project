using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraphicEffectController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EffectPrefab = new List<GameObject>();

    GameObject Particles;

    float LifeTime = 0;
 
    void Start () {
        var index = Random.Range(0, EffectPrefab.Count);

        Particles = (GameObject)Instantiate(EffectPrefab[index], 
            transform.position, EffectPrefab[index].transform.localRotation);

        Particles.transform.parent = transform;

        foreach (Transform child in Particles.transform)
        {
            child.particleSystem.renderer.sortingLayerName = "ParticleSystem";
            LifeTime = child.particleSystem.startLifetime;
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        Destroy(gameObject, LifeTime);
	}
}
