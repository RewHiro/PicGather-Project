/// ---------------------------------------------------
/// date ： 2015/01/25 
/// brief ： Twitterのツイート機能を実装
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TweetController : MonoBehaviour {

    Button ClickButton = null;

    // Use this for initialization
    void Start()
    {
        ClickButton = GetComponent<Button>();
        ClickButton.onClick.AddListener(Tweet);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Tweet()
    {
        string format = "https://twitter.com/intent/tweet?&text={0}";
        string url = string.Format(format, WWW.EscapeURL("てすと #PicGather"));
        Application.OpenURL(url);

    }

}
