using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterManager : MonoBehaviour
{

    public int ID { get; protected set; }
    public string Folder { get; protected set; }

    [SerializeField]
    CampusTemplateSetting Template = null;

    [SerializeField]
    Sprite TemplateSprite = null;


    /// <summary>
    /// データベースからIDをロードする。
    /// </summary>
    public virtual void LoadID()
    {
        ID = 2;
    }

    /// <summary>
    /// 登録する
    /// </summary>
    public void Entry()
    {
        ID++;
    }

    /// <summary>
    /// テンプレート(Sample)を設定する
    /// </summary>
    public void SetTemplate()
    {
        Template.SetSprite(TemplateSprite);
    }
}
