using UnityEngine;
using System.Collections;

public class FeverManager : MonoBehaviour {
    
    /// <summary>
    /// Feverゲージの上限、下限
    /// </summary>
    public const int MaxFeverScore = 10000;
    public const int MinFeverScore = 0;



    /// <summary>
    /// Feverゲージの量
    /// </summary>
    [Range(MinFeverScore,MaxFeverScore)]
    public static int FeverScore = MinFeverScore;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
    }

    /// <summary>
    /// 引数に与えた整の値だけ加算される
    /// </summary>
    /// <param name="addValue"></param>
    public static void AddScore(int addValue)
    {
        FeverScore += addValue;

        LimitCheck();

    }

    
    /// <summary>
    /// もし上限を超えていたり、下限を下回っていたら直す
    /// </summary>
    public static void LimitCheck()
    {

        if (FeverScore > MaxFeverScore)
        {
            FeverScore = MaxFeverScore;
        }

        if (FeverScore < MinFeverScore)
        {
            FeverScore = MinFeverScore;
        }

    }

}
