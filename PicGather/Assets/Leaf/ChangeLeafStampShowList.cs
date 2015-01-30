using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ChangeLeafStampShowList : MonoBehaviour
{

    /// <summary>
    /// Resouces内の画像データパス
    /// </summary>
    [SerializeField]
    LeafStampManagerController GraphicsPath = null;

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

    // Use this for initialization
    void Start()
    {
        /// 開始時に表示するスタンプ一覧を用意する
        IconsInitialize(CheckGraphicsNumber());

    }

    /// <summary>
    /// アイコンの数が増加時、不明時に呼び、有効な数だけアイコンを初期化する
    /// </summary>
    /// <param name="canReadNumber">アイコンがある数を渡す</param>
    private void IconsInitialize(int canReadNumber = MaxStampIconNumber)
    {
        IconsReset(canReadNumber);
        ButtonsReset(canReadNumber);
    }


    // Update is called once per frame
    void Update()
    {
        /// リストに表示する最大数以下の画像数だった場合
        if (CheckGraphicsNumber() < MaxStampIconNumber)
        {
            ChangeMode = ChangeModeID.None;
            return;
        }

        /// スクロールするかどうかをswitchで判断する
        switch (ChangeMode)
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
        if (ChangeMode != ChangeModeID.None)
        {
            IconsInitialize();
        }

        /// 一通りの処理が終えたのでスクロールしないようにする
        ChangeMode = ChangeModeID.None;

    }




    /// <summary>
    /// スタンプのアイコンを更新する
    /// </summary>
    /// <param name="canReadNumber">アイコンがある数を渡す</param>
    private void IconsReset(int canReadNumber = MaxStampIconNumber)
    {
        if (canReadNumber >= MaxStampIconNumber)
        {
            canReadNumber = MaxStampIconNumber;
        }

        for (int i = 0; i < canReadNumber; i++)
        {
            SetLeafSprite(Leaf[i], GraphicsPath.Name + "/" + (ScrollValue + (i + 1)));
        }
    }


    /// <summary>
    /// スタンプアイコンがあるかどうかをチェックして
    /// 無い場合はボタンを無効化する
    /// </summary>
    /// <param name="canReadNumber">アイコンがある数を渡す</param>
    private void ButtonsReset(int canReadNumber = MaxStampIconNumber)
    {
        for (int i = 0; i < MaxStampIconNumber; i++)
        {
            if (i < canReadNumber)
            {
                SetButtonEnabled(Leaf[i], true);
            }
            else
            {
                SetButtonEnabled(Leaf[i], false);
            }
        }
    }



    /// <summary>
    /// 第一引数の葉オブジェクトのテクスチャを第二引数のパスにあるものに変更する
    /// </summary>
    /// <param name="_gameObject">変更される葉</param>
    /// <param name="textureName">変更するテクスチャのパス</param>
    private void SetLeafSprite(GameObject _gameObject, string textureName)
    {
        var MainImage = _gameObject.GetComponent<Image>();
        var NewTexture = Resources.Load(textureName) as Texture2D;
        var NewSprite = Sprite.Create(NewTexture, new Rect(0, 0, NewTexture.width, NewTexture.height), Vector2.zero);
        MainImage.sprite = NewSprite;
    }


    /// <summary>
    /// Buttonの有効化、無効化をする
    /// </summary>
    /// <param name="_gameObject">変化を与えるGameObject</param>
    /// <param name="isEnabled">有効...true 無効...false</param>
    private void SetButtonEnabled(GameObject _gameObject, bool isEnabled)
    {
        var button = _gameObject.GetComponent<Button>();
        button.enabled = isEnabled;
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
        var graphic = Resources.Load(GraphicsPath.Name + "/" + (ScrollValue + MaxStampIconNumber + 1)) as Texture2D;
        if (graphic)
        {
            ScrollValue++;
        }
    }



    /// <summary>
    /// リストのスクロールしている値を減少させる
    /// </summary>
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

    /// <summary>
    /// フォルダ内の画像ファイルを探し、その数を返す
    /// </summary>
    private int CheckGraphicsNumber()
    {
        var gameObjectArray = Resources.LoadAll(GraphicsPath.Name + "/");

        return gameObjectArray.Length;
    }

}