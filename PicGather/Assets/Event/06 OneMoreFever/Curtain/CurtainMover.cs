using UnityEngine;
using System.Collections;

public class CurtainMover : MonoBehaviour {

    /// <summary>
    /// 移動量
    /// </summary>
    private float Velocity = 0.0f;

    /// <summary>
    /// スクリーン座標
    /// </summary>
    private Vector3 ScreenPosition = new Vector3(0.0f, 0.0f, 0.0f);
	// Use this for initialization
	void Start () {
        ScreenPosition = Camera.main.WorldToScreenPoint(transform.position);

        var MaxVelocity = Screen.width*1.0f;
        var MinVelocity = Screen.width / 2;

        Velocity = Random.Range(MinVelocity, MaxVelocity);
	}
	
	// Update is called once per frame
	void Update () {
        ScreenPosition.x -= Velocity * Time.deltaTime;

        transform.position = Camera.main.ScreenToWorldPoint(ScreenPosition);
	
	}
}
