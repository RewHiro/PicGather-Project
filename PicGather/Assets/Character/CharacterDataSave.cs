/// ---------------------------------------------------
/// date ： 2015/02/12  
/// brief ： キャラクターの保存するデータ 
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class CharacterDataSave : MonoBehaviour
{

    public CharacterData Data { get; private set; }

    /// <summary>
    /// 保存するデータを格納する。
    /// </summary>
    /// <param name="textureFilePath">生成したテクスチャパス</param>
    public void SetSaveData(string textureFilePath)
    {
        Data = new CharacterData(name, textureFilePath, transform.lossyScale);
    }

}
