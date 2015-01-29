/// ---------------------------------------------------
/// date ： 2015/01/25 
/// brief ： ローカルでキャプチャーを保存
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#if UNITY_METRO_8_1 && !UNITY_EDITOR
using LegacySystem.IO;
using WinRTPlugin;
#else
using System.IO;
#endif

public class CaptureLocalSaveController : MonoBehaviour {

    CaptureController Capture = null;

    Button ClickButton = null;

    int ID = 0;
    
	// Use this for initialization
	void Start () {
        if (!ClickButton)
        {
            ClickButton = GetComponent<Button>();
            ClickButton.onClick.AddListener(Save);
        }

        if (Capture) return;
        Capture = FindObjectOfType(typeof(CaptureController)) as CaptureController;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// 保存する。
    /// </summary>
    void Save()
    {
        ID++;
        var Path = Application.persistentDataPath + "../../../../../Desktop/Share/";
        var OutPath = string.Format("{0}{1}", Path, ID + ".jpg");
#if UNITY_METRO_8_1 && !UNITY_EDITOR
        Plugin.FileReference();
#else
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }

        var bytes = Capture.Texture.EncodeToJPG();
        Destroy(Capture.Texture);

        File.WriteAllBytes(OutPath, bytes);
#endif
    }

}
