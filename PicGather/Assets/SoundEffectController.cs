using UnityEngine;
using System.Collections;

public class SoundEffectController : MonoBehaviour {

    [SerializeField]
    AudioClip AudioEffectClip = null;
    AudioSource AudioSource;

	// Use this for initialization
	void Start () {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = AudioEffectClip;
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
