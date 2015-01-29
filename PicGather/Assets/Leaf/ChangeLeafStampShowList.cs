using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChangeLeafStampShowList : MonoBehaviour
{
    /// <summary>
    /// スクロールしない場合...None する場合...RightかLeftで方向を示す
    /// </summary>
    enum ChangeModeID
    {
        None,
        Left,
        Right
    }

    /// <summary>
    /// 表示しているスタンプの最大数
    /// </summary>
    private const int MaxStampIconNumber = 3;

    /// <summary>
    /// スタンプオブジェクトを得る
    /// </summary>
    [SerializeField]
    private GameObject[] Leaf = new GameObject[MaxStampIconNumber];

    /// <summary>
    /// スクロール方法をenumで扱う
    /// </summary>
    private ChangeModeID ChangeMode = ChangeModeID.None;

    /// <summary>
    /// スタンプのリストがいくつスクロールされているのかのカウント
    /// </summary>
    private int ScrollValue = 0;
    
    /// <summary>
    /// 画像が保存されているのパス
    /// </summary>
    private const string GraphicsPath = "Leaf/";



    // Use this for initialization
    void Start()
    {
        /// 開始時に表示するスタンプ一覧を用意する
        IconReset();
    }




    // Update is called once per frame
    void Update()
    {

        /// スクロールするかどうかをswitchで判断する
        switch(ChangeMode)
        {
            case ChangeModeID.Left:
                IncreaceScrollValue();
                break;
            case ChangeModeID.Right:
                DecreaceScrollValue();
                break;
            default:
                break;
        }

        /// スクロールされているかどうか
        if(ChangeMode != ChangeModeID.None)
        {
            IconReset();
        }
        
        /// 一通りの処理が終えたのでスクロールしないようにする
        ChangeMode = ChangeModeID.None;

    }




    /// <summary>
    /// スタンプのアイコンを更新する
    /// </summary>
    private void IconReset()
    {
        for (int i = 0; i < MaxStampIconNumber; i++)
        {
            SetLeafSprite(Leaf[i], GraphicsPath + (ScrollValue + (i + 1)));
        }
    }




    /// <summary>
    /// 第一引数の葉オブジェクトのテクスチャを第二引数のパスにあるものに変更する
    /// </summary>
    /// <param name="_gameObject">変更される葉</param>
    /// <param name="textureName">変更するテクスチャのパス</param>
    private void SetLeafSprite(GameObject _gameObject,string textureName)
    {
        var MainImage = _gameObject.GetComponent<Image>();
        var NewTexture = Resources.Load(textureName) as Texture2D;
        var NewSprite = Sprite.Create(NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height), Vector2.zero);
        MainImage.sprite = NewSprite;
    }




    /// <summary>
    /// 右にあるボタンの押し込んだ際の処理
    /// </summary>
    public void RightScroll()
    {
        ChangeMode = ChangeModeID.Right;
    }




    /// <summary>
    /// 右にあるボタンの押し込んだ際の処理
    /// </summary>
    public void LeftScroll()
    {
        ChangeMode = ChangeModeID.Left;
    }




    /// <summary>
    /// スクロール後に画像があるかどうかをチェックし、
    /// あるならスクロールする
    /// </summary>
    private void IncreaceScrollValue()
    {
        var graphic = Resources.Load(GraphicsPath + (ScrollValue + MaxStampIconNumber + 1)) as Texture2D;
        if (graphic)
        {
            ScrollValue++;
        }
    }



    /// <summary>
    /// リストのスクロールしている値を減少させる
    /// </summary>
    /// <param name="decreaceValue">減少させる値(正の値で減算されます)</param>
    private void DecreaceScrollValue()
    {
        /// マイナスの値にはいかない
        if (ScrollValue > 0)
        {
            ScrollValue--;
        }
        else
        {
            ScrollValue = 0;
        }

    }
}