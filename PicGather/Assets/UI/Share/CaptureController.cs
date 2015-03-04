/// ---------------------------------------------------
/// date ： 2015/01/19 
/// brief ： キャプチャー保存
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CaptureController : MonoBehaviour
{
    public Texture2D Texture { get; private set; }

    void Start()
    {
        Texture = null;
    }

    /// <summary>
    /// テクスチャを保存する。
    /// </summary>
    public void TextureSave()
    {
        StartCoroutine("Capture");
        ModeManager.ChangeShareMode();
    }

    /// <summary>
    /// キャプチャー処理
    /// </summary>
    /// <param name="filePath">ファイルのパスを指定</param>
    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        
        var CaptureRect = new Rect(0, 0, Screen.width, Screen.height);
        Texture = new Texture2D((int)CaptureRect.width, (int)CaptureRect.height, TextureFormat.ARGB32, false);

        Texture.ReadPixels(CaptureRect, 0, 0);
        Texture.Apply();
    }
}