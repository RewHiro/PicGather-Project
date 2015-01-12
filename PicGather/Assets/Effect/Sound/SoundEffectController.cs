/// ---------------------------------------------------
/// date ： 2015/01/09      
/// brief ： サウンドエフェクトを処理する
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffectController : MonoBehaviour {

    [SerializeField]
    List<AudioClip> AudioEffectClip = new List<AudioClip>();


    AudioSource AudioSource;

	void Start () {
        AudioPlay();
	}
	
    //  オーディオを再生
    //  ランダムで再生するクリップ指定し、再生
    void AudioPlay()
    {
        AudioSource = GetComponent<AudioSource>();

        var randomIndex = Random.Range(0, AudioEffectClip.Count);
        AudioSource.clip = AudioEffectClip[randomIndex];

        AudioSource.Play();
    }


	void Update () {
        if(!AudioSource.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
