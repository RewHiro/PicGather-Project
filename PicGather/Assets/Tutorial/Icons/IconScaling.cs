using UnityEngine;
using System.Collections;

public class IconScaling : MonoBehaviour
{

    /// <summary>
    /// 最大scale
    /// </summary>
    [SerializeField]
    private float MaxScale = 0.0016f;

    /// <summary>
    /// 何秒かけて変化するか
    /// </summary>
    private const float ChangingTime = 1.0f;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);


        iTween.ScaleTo(gameObject, iTween.Hash("x", MaxScale, "y", MaxScale, "z", MaxScale, "time", ChangingTime, "easetype", iTween.EaseType.easeOutExpo, "looptype", iTween.LoopType.loop));
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "time", ChangingTime, "easetype", iTween.EaseType.easeInExpo, "looptype", iTween.LoopType.loop));
	}

}
