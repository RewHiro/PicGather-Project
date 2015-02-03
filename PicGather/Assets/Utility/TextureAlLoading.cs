/// ---------------------------------------------------
/// date ： 2015/02/01    
/// brief ： 指定したFolderからテクスチャをすべて読み、保存する。
///         一度読み込んだファイルパスの場合は、保存してあるテクスチャから出す。
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_METRO && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
#endif

public class TextureAlLoading : MonoBehaviour {

    struct TextureData
    {
        public TextureData(string filePath, Texture2D texture)
        {
            FilePath = filePath;
            ReadTexture = texture;
        }

        public Texture2D ReadTexture;
        public string FilePath;

    };

    static List<TextureData> ReadTextureList = new List<TextureData>();

    static Texture2D TempTexture = null;

    /// <summary>
    /// ランダムでテクスチャを読み込む。
    /// </summary>
    /// <param name="character">各キャラクターのインスタンス</param>
    /// <returns>テクスチャ</returns>
    public static Texture2D RandomLoadTexture(CharacterManager character)
    {
        var randomID = Random.Range(0, character.ID + 1);

        return LoadTexture(character, randomID);
    }

    /// <summary>
    /// 指定したIDでテクスチャを読み込む
    /// </summary>
    /// <param name="character">各キャラクターのインスタンス</param>
    /// <param name="ID">読み込みたいID</param>
    /// <returns></returns>
    public static Texture2D LoadTexture(CharacterManager character,int ID)
    {
        if (character.ID == 0) return null;

        if (character.ID < ID)
        {
            ID = character.ID;
        }
        var filePath = Application.persistentDataPath + "/" + character.Name + "_" + ID + ".png";

        if (CheckFilePathSame(filePath))
        {
            return TempTexture;
        }

        return LoadImage(filePath);
    }

    /// <summary>
    /// 同じファイルパスが保存してあるかをチェックする
    /// </summary>
    /// <param name="filePath">読み込むファイルパス</param>
    /// <returns>trrue : ある false : ない</returns>
    static bool CheckFilePathSame(string filePath)
    {
        foreach (var data in ReadTextureList)
        {
            if (data.FilePath == filePath)
            {
                TempTexture = data.ReadTexture;
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// 画像を読み込む
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>テクスチャ</returns>
    static Texture2D LoadImage(string filePath)
    {
        //var bytes = File.ReadAllBytes(filePath);

        var texture = new Texture2D(128, 128);
        //texture.LoadImage(bytes);

        ReadTextureList.Add(new TextureData(filePath, texture));

        return texture;
    }
}
