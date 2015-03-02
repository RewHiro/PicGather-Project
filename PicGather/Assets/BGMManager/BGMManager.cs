using UnityEngine;
using System.Collections;

/// <summary>
/// BGMを切り替える機能
/// </summary>
public class BGMManager : MonoBehaviour {

    [SerializeField]
    BGMPlayer player = null;

    [SerializeField]
    string morningResName = string.Empty;

    [SerializeField]
    string noonResName = string.Empty;

    [SerializeField]
    string nightResName = string.Empty;

    readonly FadeTimeData fadeTime = new FadeTimeData(5.0f, 5.0f);


    /// <summary>
    /// BGMを切り替える
    /// </summary>
    void SelectPlay()
    {
        if (DateTimeController.IsMorning)
        {
            player.Play(morningResName, fadeTime);
        }
        else if (DateTimeController.IsNoon)
        {
            player.Play(noonResName, fadeTime);
        }
        else
        {
            player.Play(nightResName, fadeTime);
        }
    }

    // Use this for initialization
    void Start()
    {
        SelectPlay();
    }

    /// <summary>
    /// BGMを止める
    /// </summary>
    void Stop()
    {
        if (!DateTimeController.IsChanged) return;
        player.Stop();
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    void Play()
    {
        if (player.IsPlaying) return;

        SelectPlay();
    }

    // Update is called once per frame
    void Update()
    {
        Stop();
        Play();

    }
}
