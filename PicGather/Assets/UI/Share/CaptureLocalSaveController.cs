/// ---------------------------------------------------
/// date ： 2015/01/25 
/// brief ： ローカルでキャプチャーを保存
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#if UNITY_METRO && !UNITY_EDITOR
using LegacySystem.IO;
using WinRTPlugin;
#else
using System.IO;
using System;
#endif

public class CaptureLocalSaveController : MonoBehaviour {

    CaptureController Capture = null;

    Button ClickButton = null;

    int ID = 0;
    string FilePath = "";

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
        
#if UNITY_METRO && !UNITY_EDITOR
   //     FilePath = Plugin.GetPicturePath();
        FilePath = Application.persistentDataPath + "/Share/";
#else
        FilePath = Application.persistentDataPath + "/Share/";
#endif
        FilePath = string.Format("{0}{1}", FilePath, ID + ".jpg");

        var bytes = Capture.Texture.EncodeToJPG();
        Destroy(Capture.Texture);

       // File.WriteAllBytes(FilePath, bytes);
    }

}
