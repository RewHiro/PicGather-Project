/// ---------------------------------------------------
/// date ： 2015/01/14  
/// brief ： 雲管理クラス
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using System.Collections;

#if UNITY_METRO_8_1 && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
#endif

public class CloudManagerController : CharacterManager
{

	// Use this for initialization
	void Start () {
        Name = "Cloud";
        LoadID();

        var bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + Name + 1 + ".png");
        var texture = new Texture2D(128, 128);
        texture.LoadImage(bytes);
        texture.Apply();
        renderer.material.mainTexture = texture;
    }

	
	// Update is called once per frame
	void Update () {
	    
	}
}
