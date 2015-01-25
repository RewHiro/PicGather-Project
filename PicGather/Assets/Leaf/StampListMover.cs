using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StampListMover : MonoBehaviour {

    [SerializeField]
    AnimationClip OpenAnimClip = null;

    [SerializeField]
    AnimationClip CloseAnimClip = null;

    Animation MoveAnimation = null;
    GameModeButtonSetting UIButton = null;

    enum STATE
    {
        Open,
        Stop,
        Close,
    };

    STATE State = STATE.Close;


    // Use this for initialization
	void Start () {
        MoveAnimation = GetComponent<Animation>();
        UIButton = GetComponent<GameModeButtonSetting>();
        UIButton.AddOnClick(Open);
        UIButton.AddOnClick(Close);
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

    void Open()
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
