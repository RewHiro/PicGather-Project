using UnityEngine;
using System.Collections;

public class LeafSE : MonoBehaviour {


    [SerializeField]
    string createSEResName = string.Empty;

    SoundEffectPlayer Player = null;

    LeafCreator creator = null;

	// Use this for initialization
	void Start () {
        creator = GetComponent<LeafCreator>();
        Player = GameObject.Find("SEPlayer").GetComponent<SoundEffectPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (creator.isCreated)
        {
            Player.Play(createSEResName);
        }
	}
}
