using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RainFerverController : MonoBehaviour {

    ModeManager Mode = null;
    CharacterManager Character = null;

	// Use this for initialization
	void Start () {
        Mode = FindObjectOfType(typeof(ModeManager)) as ModeManager;
        
        if (!Mode.IsFerverMode()) return;
        var RandomCharacter = Random.Range(0, 3);

        switch(RandomCharacter)
        {
            case 0:
                Character = FindObjectOfType(typeof(FairyManagerController)) as FairyManagerController;
                break;
            case 1:
                Character = FindObjectOfType(typeof(CloudManagerController)) as CloudManagerController;
                break;
            case 2:
                Character = FindObjectOfType(typeof(LeafStampManagerController)) as LeafStampManagerController;
                break;
        }

        var TextureCampus = Resources.Load(Character.Folder + "/" + Random.Range(1, Character.ID + 1)) as Texture2D;
        renderer.material.mainTexture = TextureCampus;
        var Scale = 0.8f;
        transform.localScale = new Vector3(Scale, Scale, Scale);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
