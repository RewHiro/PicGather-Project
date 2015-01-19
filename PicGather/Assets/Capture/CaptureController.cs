using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class CaptureController : MonoBehaviour
{

    [SerializeField]
    Rect CaptureRect = new Rect(0,0,Screen.width,Screen.height);

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
        // StartCoroutine("Capture", Application.dataPath + "/Capture_" + ID + ".png");
        StartCoroutine("Capture", Application.dataPath + "/CaptureData/" + ID + ".jpg");
    }

    /// <summary>
    /// キャプチャー処理
    /// </summary>
    /// <param name="filePath">ファイルのパスを指定</param>
    IEnumerator Capture(string filePath)
    {
        yield return new WaitForEndOfFrame();

        var texture = new Texture2D((int)CaptureRect.width, (int)CaptureRect.height, TextureFormat.ARGB32, false);

        texture.ReadPixels(CaptureRect, 0, 0);
	    texture.Apply ();

        //var bytes = texture.EncodeToPNG();
        var bytes = texture.EncodeToJPG();
        Destroy(texture);

	    File.WriteAllBytes(filePath, bytes);
    }
}