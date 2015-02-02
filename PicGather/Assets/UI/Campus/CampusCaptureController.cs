
/// ---------------------------------------------------
/// date ： 2015/01/19 
/// brief ： キャプチャー保存
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#if UNITY_METRO && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
#endif


public class CampusCaptureController : MonoBehaviour
{
    [SerializeField]
    CampusTemplateSetting CampusTemplate = null;

    [SerializeField]
    GameObject CampusFrame = null;

    Rect CaptureRect = new Rect(0, 0, 0, 0);
    
    Button ClickButton = null;
    CharacterManager CharaManager = null;

    void Start()
    {
        ClickButton = GetComponent<Button>();
        ClickButton.onClick.AddListener(Save);
        SetCampusRect();
    }

    /// <summary>
    /// キャプチャーするキャンパスのRect型を設定する。
    /// </summary>
    void SetCampusRect()
    {
        var FrameRect = CampusFrame.GetComponent<RectTransform>().rect;

#if UNITY_METRO_8_1 && !UNITY_EDITOR
        var RightShift = 100;
        var DownShift = 50;
        FrameRect.x += FrameRect.width / 2 + RightShift;
        FrameRect.y += FrameRect.height / 2 + DownShift;
        FrameRect.width -= RightShift;
        FrameRect.height -= DownShift;
#else
        var RightShift = 100;
        var DownShift = 50;
        FrameRect.x += FrameRect.width / 2 + RightShift;
        FrameRect.y += FrameRect.height / 2 + DownShift;
        FrameRect.width -= RightShift*3;
        FrameRect.height -= DownShift*3;

#endif
        CaptureRect = FrameRect;
    }

    /// <summary>
    /// 保存する。
    /// </summary>
    void Save()
    {
        if (!CampusTemplate.IsSelect) return;
        if (!CharaManager.CanSave) return;

        //FilePath = Application.persistentDataPath + "/Resources/" + CharaManager.Name + "/";

        //if (!Directory.Exists(FilePath))
        //{
        //    Directory.CreateDirectory(FilePath);
        //}

        //FilePath = Application.persistentDataPath + "/Resources/" + CharaManager.Name + "/" + CharaManager.ID + ".png";

        //StartCoroutine("Capture", FilePath);

        StartCoroutine("SaveTexture");
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

        var bytes = texture.EncodeToPNG();
        Destroy(texture);

        File.WriteAllBytes(filePath, bytes);

    }

    /// <summary>
    /// キャプチャー処理
    /// キャプチャーしたテクスチャデータをまず、pngデータにエンコードする。
    /// バイト配列で画像を読み込みをしています。
    /// 読み込んだ画像をキャラクターが持っておるキャンパステクスチャに設定する。
    /// ファイルとして書き出す
    /// </summary>
    IEnumerator SaveTexture()
    {
        yield return new WaitForEndOfFrame();

        var texture = new Texture2D((int)CaptureRect.width, (int)CaptureRect.height, TextureFormat.ARGB32, false);

        texture.ReadPixels(CaptureRect, 0, 0);
        texture.Apply();

        var bytes = texture.EncodeToPNG();

        texture = new Texture2D(128, 128);
        texture.LoadImage(bytes);

        CharaManager.SetTexture2D(texture);

        var path = Application.persistentDataPath + "/" + CharaManager.Name;
        var filePath = path + "_" + CharaManager.ID + ".png";
        File.WriteAllBytes(filePath, bytes);


        CharaManager.Entry(filePath);

    }

    /// <summary>
    /// 保存するキャラクターデータを切り替える
    /// </summary>
    /// <param name="character"></param>
    public void ChangeSaveCharacter(CharacterManager character)
    {
        CharaManager = character;
    }

}