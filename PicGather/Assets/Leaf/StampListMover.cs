using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StampListMover : MonoBehaviour {

    [SerializeField]
    AnimationClip OpenAnimClip = null;

    [SerializeField]
    AnimationClip CloseAnimClip = null;

    Animation MoveAnimation = null;

    enum STATE
    {
        Open,
        Close,
    };

    STATE State = STATE.Close;

    // Use this for initialization
	void Start () {
        MoveAnimation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Open()
    {
        if (State == STATE.Open) return;

        State = STATE.Open;
        MoveAnimation.PlayQueued(OpenAnimClip.name);
    }

    public void Close()
    {
        if (State == STATE.Close) return;

        State = STATE.Close;
        MoveAnimation.PlayQueued(CloseAnimClip.name);
    }

}
