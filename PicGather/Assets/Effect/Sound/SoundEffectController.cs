using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffectController : MonoBehaviour {

    [SerializeField]
    List<AudioClip> AudioEffectClip = new List<AudioClip>();


    AudioSource AudioSource;

	// Use this for initialization
	void Start () {
        AudioSource = GetComponent<AudioSource>();

        var randomIndex = Random.Range(0, AudioEffectClip.Count);
        AudioSource.clip = AudioEffectClip[randomIndex];


        AudioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(!AudioSource.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
