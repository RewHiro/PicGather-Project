/// ---------------------------------------------------
/// date ： 2015/01/30  
/// brief ： キャラクターの親クラス
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

public class CharacterManager : MonoBehaviour
{

    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public string TextureFilePath { get; protected set; }
    public bool IsCreate { get { return (State == STATE.Create); } }
    public bool CanSave { get { return (State == STATE.None); } }
    public Texture2D CampusTexture { get; private set; }

    [SerializeField]
    CampusTemplateSetting Template = null;

    [SerializeField]
    Sprite TemplateSprite = null;

    CharacterDataWriting SaveData = null;

    enum STATE
    {
        None,       //  なにもない
        Create,     //  生成
        Appearance, //  登場
    }

    STATE State;

    /// <summary>
    /// データベースからIDをロードする。
    /// </summary>
    public virtual void Init()
    {
        SaveData = GetComponent<CharacterDataWriting>();
        ID = 0;
        State = STATE.None;
        CampusTexture = null;
    }

    /// <summary>
    /// 登録する
    /// </summary>
    public void Entry(string filePath)
    {
        if (State != STATE.None) return;

        ID++;
        TextureFilePath = filePath;
        State = STATE.Create;
    }

    /// <summary>
    /// テンプレート(Sample)を設定する
    /// </summary>
    public void SetTemplate()
    {
        Template.SetSprite(TemplateSprite);
    }

    /// <summary>
    /// 生成された時の処理
    /// </summary>
    public void Created()
    {
        State = STATE.Appearance;
    }

    /// <summary>
    /// なにもない状態にする
    /// </summary>
    public void NoneState()
    {
        State = STATE.None;
    }

    /// <summary>
    /// お絵かきしたテクスチャデータを設定する。
    /// </summary>
    /// <param name="texture">テクスチャデータ</param>
    public void SetTexture2D(Texture2D texture)
    {
        CampusTexture = texture;
    }

    /// <summary>
    /// 生成した子オブジェクトのデータを保存する。
    /// </summary>
    /// <param name="clone">生成するオブジェクト</param>
    public void CreateChildrenDataSave(GameObject clone)
    {
        var children = clone.GetComponent<CharacterDataSave>();
        children.SetSaveData(ID,TextureFilePath);
    }

    /// <summary>
    /// 子オブジェクトのデータ保存。
    /// ファイルに書き出す
    /// </summary>
    public void ChildrensDataSave()
    {
        var childrens = GameObject.FindGameObjectsWithTag(Name);

        foreach (var children in childrens)
        {
            var character = children.GetComponent<CharacterDataSave>();
            SaveData.Write(new CharacterData(character.Data.ID, character.Data.Name, character.Data.TextureFilePath, character.transform.lossyScale));
        }

        SaveData.FileWrite(Name);
    }
}