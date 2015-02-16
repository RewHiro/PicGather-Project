using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FeverGraphicEffect : MonoBehaviour {

    [SerializeField]
    GameObject Prefab = null;

    [SerializeField]
    List<Texture> NoteSprite = new List<Texture>();

    float Count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ModeManager.IsFerverMode) return;

        Count += Time.deltaTime;
        if (Count >= 1)
        {
            var clone = (GameObject)Instantiate(Prefab, transform.position, transform.rotation);
            clone.transform.parent = transform;
            var index = Random.Range(0, NoteSprite.Count);
            clone.renderer.material.mainTexture = NoteSprite[index];
        }

	}
}
