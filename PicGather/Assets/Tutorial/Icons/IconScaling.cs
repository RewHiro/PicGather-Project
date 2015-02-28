using UnityEngine;
using System.Collections;

public class IconScaling : MonoBehaviour
{

    [SerializeField]
    private float MaxScale = 0.0016f;

    private const float ChangingTime = 1.0f;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);


        iTween.ScaleTo(gameObject, iTween.Hash("x", MaxScale, "y", MaxScale, "z", MaxScale, "time", ChangingTime, "easetype", iTween.EaseType.easeOutExpo, "looptype", iTween.LoopType.loop));
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "time", ChangingTime, "easetype", iTween.EaseType.easeInExpo, "looptype", iTween.LoopType.loop));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
