using UnityEngine;
using System.Collections;

public class WaterSurfaceScaling : MonoBehaviour {

    /// <summary>
    /// Scaleの最大値
    /// </summary>
    private const float MaxScale = 6.0f;
    /// <summary>
    /// Scaleの最小値
    /// </summary>
    private const float MinScale = 0.0f;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       // SetScaleByfloat(MaxScale * Mathf.Sin((FeverManager.FeverScore * 2.0f / FeverManager.MaxFeverScore) * Mathf.PI));

        ScaleCheck();

	}

    /// <summary>
    /// もし上限を超えていたり、下限を下回っていたら直す
    /// </summary>
    private void ScaleCheck()
    {

        if (transform.localScale.x > MaxScale || transform.localScale.y > MaxScale && transform.localScale.z > MaxScale) SetScaleByfloat(MaxScale);
        if (transform.localScale.x < MinScale || transform.localScale.y < MinScale || transform.localScale.z < MinScale) SetScaleByfloat(MinScale);
    }

    /// <summary>
    /// 1つのfloat型の引数でx,y,zのScaleを設定する
    /// </summary>
    /// <param name="scaleValue"></param>
    private void SetScaleByfloat(float scaleValue)
    {
        transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }

}
