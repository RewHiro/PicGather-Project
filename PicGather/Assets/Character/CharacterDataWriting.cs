
/// ---------------------------------------------------
/// date ： 2015/02/02 
/// brief ： Jsonを使いキャラクターのデータを出力する
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

#if UNITY_METRO && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
#endif

public struct Vec3J
{
    public Vec3J(float p1, float p2, float p3)
        : this()
    {
        X = p1;
        Y = p2;
        Z = p3;
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
};

public struct CharacterData
{
    public CharacterData(int id,string name, string textureFilePath, Vector3 scale):this()
    {
        ID = id;
        Name = name;
        TextureFilePath = textureFilePath;
        Scale = new Vec3J(scale.x, scale.y, scale.z);
    }

    public Vec3J Scale { get; set; }
    public string Name { get; set; }
    public string TextureFilePath { get; set; }
    public int ID { get; set; }
};


public class CharacterDataWriting : MonoBehaviour
{
    List<CharacterData> DataList = new List<CharacterData>();

    /// <summary>
    /// 1体のキャラクターデータを書き出す。
    /// </summary>
    /// <param name="name">キャラクターの名前</param>
    /// <param name="textureFilePath">キャラクターの貼られているテクスチャパス名</param>
    /// <param name="scale">キャラクターのスケール</param>
    /// <param name="isPresence">存在してたら true, 存在してないなら false</param>
    public void Write(CharacterData saveCharacterData)
    {
        DataList.Add(saveCharacterData);
    }


    /// <summary>
    /// ファイルに書き出す
    /// </summary>
    public void FileWrite(string name)
    {
        string json = LitJson.JsonMapper.ToJson(DataList);

        var path = Application.persistentDataPath + "/" + name + ".json";

       // File.WriteAllText(path, json);

    }

}
