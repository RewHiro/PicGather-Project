using UnityEngine;
using System.Collections;

public class FairySE : MonoBehaviour {

    FairyMover mover = null;
    FairyEating eating = null;
    AudioSource[] sounds = new AudioSource[2];




    // Use this for initialization
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        mover = GetComponent<FairyMover>();
        eating = GetComponent<FairyEating>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mover.IsAbsorption)
        {
            if (sounds[0].isPlaying) return;
            sounds[1].Stop();
            sounds[0].Play();
        }
        else if (mover.IsMove)
        {
            if (sounds[1].isPlaying) return;
            sounds[1].Play();
        }
        else
        {
            sounds[1].Stop();
        }

    }
}
