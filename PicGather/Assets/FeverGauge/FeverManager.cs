using UnityEngine;
using System.Collections;

public class FeverManager : MonoBehaviour {

    FeverSoundController Sound = null;

    /// <summary>
    /// Feverゲージの上限、下限
    /// </summary>
    public const int MaxFeverScore = 10;
    public const int MinFeverScore = 0;

    /// <summary>
    /// Feverゲージの量
    /// </summary>
    public int FeverScore{get;private set;}


	// Use this for initialization
	void Start () {
        FeverScore = MinFeverScore;
        Sound = GetComponent<FeverSoundController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (ModeManager.IsGameMode)
        {
            //AddScore(10);
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

        Debug.Log(FeverScore);

    }

    
    /// <summary>
    /// もし上限を超えていたり、下限を下回っていたら直す
    /// </summary>
    void LimitCheck()
    {
        if (FeverScore > MaxFeverScore && !ModeManager.IsFerverMode)
        {
            FeverScore = MaxFeverScore;
            ModeManager.ChangeFerverMode();
            Sound.Play();
        }

        if (FeverScore < MinFeverScore && ModeManager.IsFerverMode)
        {
            FeverScore = MinFeverScore;
            ModeManager.ChangeGameMode();
            Sound.Stop();
        }
    }


    void Ferver()
    {
        if (!ModeManager.IsFerverMode) return;
        AddScore(-1);
    }
}
