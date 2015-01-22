using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour {

    enum STATE
    {
        Game,
        Drawing,
    };

    STATE State = STATE.Game;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsGameMode()
    {
        return (State == STATE.Game);
    }

    public bool IsDrawingMode()
    {
        return (State == STATE.Drawing);
    }

    public void ChangeDrawingMode()
    {
        State = STATE.Drawing;
    }

    public void ChangeGameMode()
    {
        State = STATE.Game;
    }

}
