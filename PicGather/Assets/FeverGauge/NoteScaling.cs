using UnityEngine;
using System.Collections;

public class NoteScaling : MonoBehaviour {

    [SerializeField]
    float MaxTime = 3.0f;

    [SerializeField]
    float MaxScale = 3.0f;

    // Use this for initialization
    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(MaxScale, MaxScale, MaxScale),
                        "time", MaxTime, "easetype", iTween.EaseType.easeInExpo));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
