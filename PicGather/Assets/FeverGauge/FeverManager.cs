using UnityEngine;
using System.Collections;

public class FeverManager : MonoBehaviour {

    FeverSoundController Sound = null;

    [SerializeField]
    AllDataSave AllSave = null;

    [SerializeField]
    float FeverTime = 30.0f;

    [SerializeField]
    float AddSpeed = 2.0f;

    /// <summary>
    /// Feverゲージの上限、下限
    /// </summary>
    public float MaxFeverScore {get;private set;}
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
        MaxFeverScore = 5;

        FeverScore = MinFeverScore;
        Sound = GetComponent<FeverSoundController>();
        Data = GetComponent<FeverDataController>();

        if (Data.GetLoadData().Times < 0) return;

        NumTimes = Data.GetLoadData().Times;
        MaxFeverScore = Data.GetLoadData().MaxScore;
        FeverScore = Data.GetLoadData().NowScore;
	}
	
	// Update is called once per frame
	void Update () {

        Increase();
        LimitCheck();


        if (Input.GetKeyDown(KeyCode.A))
        {
            AddScore(3.0f);
        }
    }

    /// <summary>
    /// フィーバーゲージが増加する
    /// </summary>
    void Increase()
    {

        if (IsIncrease)
        {
            FeverScore += AddSpeed *Time.deltaTime;
            if (FeverScore >= IncreaseScore)
            {
                IsIncrease = false;
                AllSave.AllSave();
                Ferver(IncreaseScore);
            }
        }

    }

    /// <summary>
    /// 引数に与えた整の値だけ加算される
    /// </summary>
    /// <param name="addValue"></param>
    public void AddScore(float addValue)
    {
        IncreaseScore += addValue;
        IsIncrease = true;

        if (!ModeManager.IsGameMode)
        {
            IsIncrease = false;
        }
    }
    
    /// <summary>
    /// もし上限を超えていたり、下限を下回っていたら直す
    /// </summary>
    void LimitCheck()
    {
        if (FeverScore > MaxFeverScore && ModeManager.IsGameMode)
        {
            MaxFeverScore *= 3;
            FeverScore = MaxFeverScore;
            IncreaseScore = 0;
            ModeManager.ChangeFerverMode();
            Sound.Play();
            UIEnabled.Unavailable();
            Ferver(MaxFeverScore);
            NumTimes++;
        }

        if (FeverScore <= MinFeverScore )
        {
            if (ModeManager.IsFerverMode || ModeManager.IsResetMode || ModeManager.IsShareMode)
            {
                FeverScore = MinFeverScore;
                ModeManager.ChangeGameMode();
                Sound.Stop();
                UIEnabled.Enabled();
                AllSave.AllSave();
            }
        }
    }

    void Ferver(float maxScore)
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", maxScore, "to", MinFeverScore, "time", FeverTime, "onupdate", "UpdateHandler"));
    }

    void UpdateHandler(float value)
    {
        FeverScore = value;
    }

    public void Save()
    {
        Data.Write(new FeverData(NumTimes, FeverScore,MaxFeverScore));
    }
}
