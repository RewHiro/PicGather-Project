/// ---------------------------------------------------
/// date ： 2015/01/20 
/// brief ： Facebookのログイン / シェア
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FBController : MonoBehaviour {
    CaptureController Capture = null;

    Button ClickButton = null;
    
    // Dictionary<string, string> Profile = null;
    void Awake()
    {
        FB.Init(SetInit, OnHideUnity);
        ClickButton = GetComponent<Button>();
      //  ClickButton.onClick.AddListener(Login);
    }

    void Start()
    {
        Capture = FindObjectOfType(typeof(CaptureController)) as CaptureController;

    }

    /// <summary>
    /// 初期化
    /// </summary>
    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
        }
        else
        {
        }
    }

    /// <summary>
    /// Unityを隠す
    /// </summary>
    /// <param name="isGameShown"></param>
    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// シェア機能
    /// </summary>
    void Share()
    {
        PostAPICapturePicture();
        ShareWithFriends();
    }

    bool _loggedIn = false;

    /// <summary>
    /// ログイン機能
    /// </summary>
    void Login()
    {
        if (FB.IsLoggedIn)
        {
            Share();
        }
        else
        {
            FB.Login("email", AuthCallback);
        }
    }

    void AuthCallback(FBResult result)
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("ログイン成功");
            Share();
        }
        else
        {
            Debug.Log("キャンセル");
        }
    }

    /// <summary>
    /// キャプチャーした画像をユーザーの写真に送信する
    /// </summary>
    /// <param name="result"></param>
    void PostCapturePicture(FBResult result)
    {
        if (result.Error != null)
        {
            Debug.Log("Post CapturePicture Error");

            PostAPICapturePicture();
            return;
        }
    }

    /// <summary>
    /// APIでのキャプチャーした画像をユーザーの写真に送信する。
    /// </summary>
    void PostAPICapturePicture()
    {
        var bytes = Capture.Texture.EncodeToJPG();
        var wwwForm = new WWWForm();
        wwwForm.AddBinaryData("image", bytes, "InteractiveConsole.png");

      //  FB.API("me/photos", Facebook.HttpMethod.POST, PostCapturePicture, wwwForm);
    }
    /// <summary>
    /// プロフィールの画像を取得
    /// </summary>
    /// <param name="result"></param>
    void GetProfilePicture(FBResult result)
    {
        if (result.Error != null)
        {
            Debug.Log("Get ProfilePicture Error");

            GetAPIProfilePicture();
            return;
        }
    }

    /// <summary>
    /// ユーザー名を取得する。
    /// </summary>
    /// <param name="result"></param>
    void GetUserName(FBResult result)
    {
        if (result.Error != null)
        {
            Debug.Log("Get UserName Error");

            GetAPIUserName();
            return;
        }

        // Profile = Util.DeserializeJSONProfile(result.Text);
        // var FirstName = profile["first_name"];
    }

    /// <summary>
    /// APIでのプロフィール画像を取得
    /// </summary>
    void GetAPIProfilePicture()
    {
     //   FB.API(Util.GetPictureURL("me", 128, 128), Facebook.HttpMethod.GET, GetProfilePicture);
    }

    /// <summary>
    /// APIでのユーザー名を取得
    /// </summary>
    void GetAPIUserName()
    {
     //   FB.API("/me?fields=id,first_name,last_name", Facebook.HttpMethod.GET, GetUserName);
    }

    /// <summary>7
    /// 友達にシェアをする。
    /// 投稿画面が出る。
    /// </summary>
    void ShareWithFriends()
    {
        FB.Feed(
            linkCaption: "タイトル",
            picture: "http://img1.prtls.jp/images/snsmk/service/ugp2012/member/0/925ccf127de917001.png",
            linkName: "内容",
            link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")
            );

    }

    /// <summary>
    /// 友達に招待文を送ることができる。
    /// </summary>
    void InviteFriends()
    {
        FB.AppRequest(
            message: "This game is awesom, join me. now",
            title: "Invite your friends to join youu"
            );
    }

}
