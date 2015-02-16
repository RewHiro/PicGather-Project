using UnityEngine;
using System.Collections;

public class FeverManager : MonoBehaviour {

    FeverSoundController Sound = null;

    /// <summary>
    /// Feverゲージの上限、下限
    /// </summary>
    public const float MaxFeverScore = 5;
    public const float MinFeverScore = 0;

    /// <summary>
    /// Feverゲージの量
    /// </summary>
    public float FeverScore { get; private set; }

    const float FeverTime = 30.0f;
    float IncreaseScore = 0;
    bool IsIncrease = false;

	// Use this for initialization
	void Start () {
        FeverScore = MinFeverScore;
        Sound = GetComponent<FeverSoundController>();
	}
	
	// Update is called once per frame
	void Update () {
        Increase();
        Ferver();
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
        }

        if (FeverScore < MinFeverScore && ModeManager.IsFerverMode)
        {
            FeverScore = MinFeverScore;
            ModeManager.ChangeGameMode();
            Sound.Stop();
            UIEnabled.Enabled();

        }
    }


    void Ferver()
    {
        if (!ModeManager.IsFerverMode) return;

        FeverScore -= Time.deltaTime / 6;
        //FeverScore -= Time.deltaTime / 10;
    }
  
}
