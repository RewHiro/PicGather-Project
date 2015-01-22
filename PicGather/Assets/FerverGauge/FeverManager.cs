using UnityEngine;
using System.Collections;

public class FeverManager : MonoBehaviour {

    [SerializeField]
    ModeManager Mode = null;

    FerverSoundController Sound = null;

    /// <summary>
    /// Feverゲージの上限、下限
    /// </summary>
    public const int MaxFeverScore = 10000;
    public const int MinFeverScore = 0;

    /// <summary>
    /// Feverゲージの量
    /// </summary>
    public int FeverScore{get;private set;}


	// Use this for initialization
	void Start () {
        FeverScore = MinFeverScore;
        Sound = GetComponent<FerverSoundController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Mode.IsGameMode())
        {
            AddScore(10);
        }
        Ferver();
    }

    /// <summary>
    /// 引数に与えた整の値だけ加算される
    /// </summary>
    /// <param name="addValue"></param>
    public void AddScore(int addValue)
    {
        FeverScore += addValue;

        LimitCheck();

    }

    
    /// <summary>
    /// もし上限を超えていたり、下限を下回っていたら直す
    /// </summary>
    void LimitCheck()
    {
        if (FeverScore > MaxFeverScore && !Mode.IsFerverMode())
        {
            FeverScore = MaxFeverScore;
            Mode.ChangeFerverMode();
            Sound.Play();
        }

        if (FeverScore < MinFeverScore && Mode.IsFerverMode())
        {
            FeverScore = MinFeverScore;
            Mode.ChangeGameMode();
            Sound.Stop();
        }
    }


    void Ferver()
    {
        if (!Mode.IsFerverMode()) return;
        AddScore(-10);
    }
}
