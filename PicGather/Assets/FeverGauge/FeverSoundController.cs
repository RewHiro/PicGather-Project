/// ---------------------------------------------------
/// date ： 2015/01/22  
/// brief ： フィーバーのサウンドコントロール
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FeverSoundController : MonoBehaviour {

    [SerializeField]
    List<AudioClip> Audio = new List<AudioClip>();

    AudioSource Source = null;

    enum FADE
    {
        None,
        In,
        Out
    };
    FADE Fade = FADE.None;

	// Use this for initialization
	void Start () {
        Source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        FadeIn();
        FadeOut();
	}

    /// <summary>
    /// フェードイン
    /// </summary>
    void FadeIn()
    {
        if (Fade != FADE.In) return;

        Source.volume += 0.001f;
        if (Source.volume > 1.0f)
        {
            Fade = FADE.None;
        }
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    void FadeOut()
    {
        if (Fade != FADE.Out) return;

        Source.volume -= 0.005f;
        if (Source.volume < 0)
        {
            Fade = FADE.None;
            Source.Stop();
        }
    }

    /// <summary>
    /// 再生
    /// </summary>
    public void Play()
    {
        Source.clip = Audio[Random.Range(0, Audio.Count)];
        Source.Play();
        Source.volume = 0.0f;
        Fade = FADE.In;
    }
    
    /// <summary>
    /// 停止
    /// </summary>
    public void Stop()
    {
        Fade = FADE.Out;
    }
}
