using UnityEngine;
using System.Collections;

public class TreeSE : MonoBehaviour {

    TreeChanger treeChanger = null;

    [SerializeField]
    string ResName = string.Empty;

    [SerializeField]
    SoundEffectPlayer Player = null;

	// Use this for initialization
	void Start () {
        treeChanger = gameObject.GetComponent<TreeChanger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (treeChanger.isGrow)
        {
            Player.Play(ResName);
        }
	}
}
