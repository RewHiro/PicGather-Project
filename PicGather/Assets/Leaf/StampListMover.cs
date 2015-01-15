using UnityEngine;
using System.Collections;

public class StampListMover : MonoBehaviour {

    [SerializeField]
    AnimationClip OpenAnimClip = null;

    [SerializeField]
    AnimationClip CloseAnimClip = null;

    Animation MoveAnimation = null;

    enum State
    {
        Open,
        Close,
    };

    State state = State.Close;

    // Use this for initialization
	void Start () {
        MoveAnimation = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Open()
    {
        if (state == State.Open) return;

        state = State.Open;
        MoveAnimation.PlayQueued(OpenAnimClip.name);
    }

    public void Close()
    {
        if (state == State.Close) return;

        state = State.Close;
        MoveAnimation.PlayQueued(CloseAnimClip.name);
    }

}
