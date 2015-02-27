using UnityEngine;
using System.Collections;

public class AppearanceSE : MonoBehaviour {

    [SerializeField]
    string ResName = string.Empty;

    [SerializeField]
    SoundEffectPlayer Player = null;

    CharacterCreator fairyCreator = null;

	// Use this for initialization
	void Start () {
        fairyCreator = GetComponent<CharacterCreator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (fairyCreator.appearanceSE)
        {
            Player.Play(ResName);
        }
	}
}
