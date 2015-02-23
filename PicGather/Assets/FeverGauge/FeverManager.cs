using UnityEngine;
using System.Collections;

public class FeverManager : MonoBehaviour {

    FeverSoundController Sound = null;

    [SerializeField]
    float FeverTime = 30.0f;

    /// <summary>
    /// Feverゲージの上限、下限
    /// </summary>
    public const float MaxFeverScore = 5;
    public const float MinFeverScore = 0;

    /// <summary>
    /// Feverゲージの量
    /// </summary>
    public float FeverScore { get; private set; }
    
    /// <summary>
    /// 回数
    /// </summary>
    public int NumTimes { get; private set; }

    float IncreaseScore = 0;
    bool IsIncrease = false;
    FeverDataController Data = null;

	// Use this for initialization
	void Start () {
        FeverScore = MinFeverScore;
        Sound = GetComponent<FeverSoundController>();
        Data = GetComponent<FeverDataController>();

        if (Data.GetLoadData().Times < 0) return;

        NumTimes = Data.GetLoadData().Times;
        Debug.Log(NumTimes);
	}
	
	// Update is called once per frame
	void Update () {
        Increase();
        LimitCheck();
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddScore(0.5f);
        }
    }

    /// <summary>
    /// フィーバーゲージが増加する
    /// </summary>
    void Increase()
    {
        if (ModeManager.IsFerverMode) return;

        if (IsIncrease)
        {
            FeverScore += Time.deltaTime;
            if (FeverScore > IncreaseScore)
            {
                IsIncrease = false;
            }
        }

    }

    /// <summary>
    /// 引数に与えた整の値だけ加算される
    /// </summary>
    /// <param name="addValue"></param>
    public void AddScore(float addValue)
    {
        if (ModeManager.IsFerverMode) return;

        IncreaseScore += addValue;
        IsIncrease = true;

    }

    
    /// <summary>
    /// もし上限を超えていたり、下限を下回っていたら直す
    /// </summary>
    void LimitCheck()
    {
        if (FeverScore > MaxFeverScore && !ModeManager.IsFerverMode)
        {
            IncreaseScore = 0;
            FeverScore = MaxFeverScore;
            ModeManager.ChangeFerverMode();
            Sound.Play();
            UIEnabled.Unavailable();
            NumTimes++;
            Ferver();
            Data.Write(NumTimes);
        }

        if (FeverScore <= MinFeverScore && ModeManager.IsFerverMode)
        {
            FeverScore = MinFeverScore;
            ModeManager.ChangeGameMode();
            Sound.Stop();
            UIEnabled.Enabled();

        }
    }


    void Ferver()
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", MaxFeverScore, "to", MinFeverScore, "time", FeverTime, "onupdate", "UpdateHandler"));
    }

    void UpdateHandler(float value)
    {
        FeverScore = value;
    }
 
  
}
