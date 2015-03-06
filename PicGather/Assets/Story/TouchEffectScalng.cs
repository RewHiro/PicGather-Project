using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchEffectScalng : MonoBehaviour
{
    [SerializeField]
    private float MinScale = 0.0f;

    [SerializeField]
    private float MaxScale = 0.0f;

    [SerializeField]
    private float ChangingTime = 1.0f;

    private Image ThisImage = null;

    [SerializeField, Range(0.0f,1.0f)]
    private float MinAlpha = 0.0f;
    
    [SerializeField, Range(0.0f, 1.0f)]
    private float MaxAlpha = 1.0f;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(MinScale,MinScale,MinScale);

        iTween.ScaleTo(gameObject, iTween.Hash("x", MaxScale, "y", MaxScale, "z", MaxScale, "time", ChangingTime, "easetype", iTween.EaseType.easeOutExpo));

        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "time", ChangingTime,"easetype",iTween.EaseType.easeInCubic));
	
        Destroy(gameObject, ChangingTime);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
