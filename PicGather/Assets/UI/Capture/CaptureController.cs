/// ---------------------------------------------------
/// date ： 2015/01/19 
/// brief ： キャプチャー保存
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class CaptureController : MonoBehaviour
{
    Button ClickButton = null;

    int ID = 0;

    void Start()
    {
        ClickButton = GetComponent<Button>();
        ClickButton.onClick.AddListener(Save);
    }

    /// <summary>
    /// 保存する。
    /// </summary>
    void Save()
    {
        ID++;
        string Path = Application.persistentDataPath + "../../../../../Desktop/Share/";
        string OutPath = string.Format("{0}/{1}", Path, ID + ".jpg");
        System.IO.Directory.CreateDirectory(Path);

        StartCoroutine("Capture", OutPath);
    }

    /// <summary>
    /// キャプチャー処理
    /// </summary>
    /// <param name="filePath">ファイルのパスを指定</param>
    IEnumerator Capture(string filePath)
    {
        yield return new WaitForEndOfFrame();
        
        const float Space = 150;
        var CaptureRect = new Rect(Space, 0, Screen.width - Space, Screen.height);
        var texture = new Texture2D((int)CaptureRect.width, (int)CaptureRect.height, TextureFormat.ARGB32, false);

        texture.ReadPixels(CaptureRect, 0, 0);
	    texture.Apply ();

        var bytes = texture.EncodeToJPG();
        Destroy(texture);

	    File.WriteAllBytes(filePath, bytes);
    }
}