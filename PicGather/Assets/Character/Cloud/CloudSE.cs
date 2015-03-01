using UnityEngine;
using System.Collections;

public class CloudSE : MonoBehaviour {

    CloudMover mover = null;

	// Use this for initialization
	void Start () {
        mover = GetComponent<CloudMover>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mover.IsRain)
        {
            if (audio.isPlaying) return;
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
	}
}
