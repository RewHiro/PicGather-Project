using UnityEngine;
using System.Collections;

public class SESample : MonoBehaviour {

    [SerializeField]
    string ResName = string.Empty;

    [SerializeField]
    SoundEffectPlayer Player = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Player.Play(ResName);
        }
	}
}
