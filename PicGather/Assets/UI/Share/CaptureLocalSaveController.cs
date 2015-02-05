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
using Windows.Storage;
using Windows.Storage.Streams;
using System;
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
        
        var bytes = Capture.Texture.EncodeToJPG();

#if UNITY_METRO && !UNITY_EDITOR
        LibForWinRT.WriteSharePicture("PicGather", ID + ".jpg", bytes);
#else
        var FilePath = Application.persistentDataPath + "/Share/";
        FilePath = string.Format("{0}{1}", FilePath, ID + ".jpg");

        File.WriteAllBytes(FilePath, bytes);
#endif
    }
}
