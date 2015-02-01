using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StampListMover : MonoBehaviour {

    public enum STATE
    {
        Open,
        Stop,
        Close,
    };

    [SerializeField]
    AnimationClip OpenAnimClip = null;

    [SerializeField]
    AnimationClip CloseAnimClip = null;

    Animation MoveAnimation = null;

    public bool IsCreate { get { return (State == STATE.Stop); } }

    STATE State = STATE.Close;

    // Use this for initialization
	void Start () {
        MoveAnimation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (State == STATE.Open)
        {
            if (!MoveAnimation.isPlaying)
            {
                State = STATE.Stop;
            }
        }

	}

    public void Open()
    {
        if (State != STATE.Close) return;

        State = STATE.Open;
        MoveAnimation.PlayQueued(OpenAnimClip.name);
    }

    public void Close()
    {
        if (State != STATE.Stop) return;

        State = STATE.Close;
        MoveAnimation.PlayQueued(CloseAnimClip.name);
    }

}
