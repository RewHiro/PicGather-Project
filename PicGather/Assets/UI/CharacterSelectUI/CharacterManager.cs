using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#if UNITY_METRO_8_1 && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
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
    public virtual void LoadID()
    {
        ID = 0;
        State = STATE.None;
        CampusTexture = null;
    }

    /// <summary>
    /// 登録する
    /// </summary>
    public void Entry()
    {
        if (State != STATE.None) return;

        ID++;
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
    /// バイト配列で画像を読み込みをしています。
    /// 読み込んだ画像をキャラクターが持っておるキャンパステクスチャに設定する。
    /// ファイルとして書き出す
    /// </summary>
    /// <param name="bytes">テクスチャのバイト配列</param>
    public void SetBytesToLoadImage(byte[] bytes)
    {
        var tex = new Texture2D(128, 128);
        tex.LoadImage(bytes);

        CampusTexture = tex;

        Destroy(tex);

        File.WriteAllBytes(Application.persistentDataPath + "/" + Name + ID + ".png", bytes);
    }
}
