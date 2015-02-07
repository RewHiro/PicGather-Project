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
using MiniJSON;
#endif

public class CharacterManager : MonoBehaviour
{

    public int ID { get; protected set; }
    public string Name { get; protected set; }
    public bool IsCreate { get { return (State == STATE.Create); } }
    public bool CanSave { get { return (State == STATE.None); } }
    public Texture2D CampusTexture { get; private set; }

    [SerializeField]
    CampusTemplateSetting Template = null;

    [SerializeField]
    Sprite TemplateSprite = null;

    [SerializeField]
    GameObject ChildrenPrefab = null;

    CharacterDataWriting SaveData = null;

    enum STATE
    {
        None,       //  なにもない
        Create,     //  生成
        Appearance, //  登場
    }

    STATE State;

    void Start()
    {
        Init();   
    }

    /// <summary>
    /// データベースからIDをロードする。
    /// </summary>
    public virtual void Init()
    {
        SaveData = GetComponent<CharacterDataWriting>();
        State = STATE.None;
        CampusTexture = null;
        DataLoading();
    }

    /// <summary>
    /// データロード
    /// </summary>
    void DataLoading()
    {
        var path = Application.persistentDataPath + "/Database/" + Name + ".json";

        if (!File.Exists(path)) return;

        var jsonText = File.ReadAllText(path);

        var json = LitJson.JsonMapper.ToObject<CharacterData[]>(jsonText);

        foreach (var chara in json)
        {
            Debug.Log(chara.ID);
            Debug.Log(chara.Name);
            if (chara.Name == name)
            {
                ID = chara.ID;
            }
            else 
            {
                ChildrensDataLoad(chara.Name,chara.ID,chara.Pos,chara.Scale);
            }
        }

    }

    /// <summary>
    /// 子オブジェクトのデータを読み込む
    /// </summary>
    /// <param name="name">名前</param>
    /// <param name="id">ID</param>
    /// <param name="pos">座標</param>
    /// <param name="scale">Scale</param>
    void ChildrensDataLoad(string name, int id, Vec3J pos, Vec3J scale)
    {
        var clonePos = new Vector3(pos.X,pos.Y,pos.Z);
        var cloneScale = new Vector3(scale.X,scale.Y,scale.Z);
        var clone = (GameObject)Instantiate(ChildrenPrefab, clonePos, Quaternion.identity);
        
        clone.name = name;
        clone.transform.parent = transform;
        clone.transform.lossyScale.Scale(cloneScale);

        var bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + name + "/" + id + ".png");
        var texture = new Texture2D(128, 128);
        texture.LoadImage(bytes);

        clone.renderer.material.mainTexture = texture;
    }

    /// <summary>
    /// 登録する
    /// </summary>
    public void Entry()
    {
        if (State != STATE.None) return;

        ID++;
        State = STATE.Create;
        SaveData.Write(new CharacterData(ID, name, Vector3.zero, Vector3.zero));
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
        children.SetSaveData(ID);
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
            SaveData.Write(new CharacterData(character.Data.ID, character.name,
                            character.transform.position, character.transform.lossyScale));
        }

        SaveData.FileWrite(Name);
    }
}