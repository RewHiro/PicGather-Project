/// ---------------------------------------------------
/// date ： 2015/01/28    
/// brief ： キャラクターを生成する
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;


#if UNITY_METRO_8_1 && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
#endif

public class CharacterCreator : MonoBehaviour {

    [SerializeField]
    GameObject Prefab = null;

    [SerializeField]
    CharacterManager Manager = null;

    void Update()
    {
        if (!Manager.IsCreate) return;

        StartCoroutine("Create");

        Manager.Created();
    }

    /// <summary>
    /// 少し待ってから生成するようにする
    /// もし、Resourcesで読み込みが失敗した場合は絶対パスで取得するようにしている。
    /// </summary>
    /// <returns></returns>
    IEnumerator Create()
    {
        yield return new WaitForSeconds(3.0f);

        var ReadPath = Manager.Name + "/" + Manager.ID;
        var TextureCampus = Resources.Load(ReadPath) as Texture2D;

        if (!TextureCampus)
        {
            TextureCampus = ReadTexture(Application.dataPath + "/Resources/" + ReadPath + ".png", 800, 500);
        }

        var Clone = (GameObject)Instantiate(Prefab, new Vector3(0, 100, 0), Prefab.transform.rotation);
        Clone.name = Prefab.name;
        Clone.renderer.material.mainTexture = TextureCampus;

        Manager.NoneState();

    }

    /// <summary>
    /// PNGファイルを読み込む
    /// </summary>
    /// <param name="path">画像パス</param>
    /// <returns>バイトの値</returns>
    byte[] ReadPngFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }

    /// <summary>
    /// テクスチャとして読み込む
    /// </summary>
    /// <param name="path">画像パス</param>
    /// <param name="width">読み込む横幅</param>
    /// <param name="height">読み込む縦幅</param>
    /// <returns>テクスチャデータ</returns>
    Texture2D ReadTexture(string path, int width, int height)
    {
        byte[] readBinary = ReadPngFile(path);

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);

        return texture;
    }
}
