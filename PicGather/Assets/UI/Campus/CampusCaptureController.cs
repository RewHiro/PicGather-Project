
/// ---------------------------------------------------
/// date ： 2015/01/19 
/// brief ： キャプチャー保存
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#if UNITY_METRO_8_1 && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
#endif

public class CampusCaptureController : MonoBehaviour
{
    [SerializeField]
    CampusTemplateSetting CampusTemplate = null;

    readonly Rect CaptureRect = new Rect(25, -50, 325, 200);
    
    Button ClickButton = null;
    CharacterManager CharaManager = null;

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
        if (!CampusTemplate.IsSelect) return;

        CharaManager.Entry();
        StartCoroutine("Capture", Application.dataPath + "/Resrouces/" + CharaManager.Folder + "/" + CharaManager.ID + ".png");
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
    /// 保存するキャラクターデータを切り替える
    /// </summary>
    /// <param name="character"></param>
    public void ChangeSaveCharacter(CharacterManager character)
    {
        CharaManager = character;
    }

}