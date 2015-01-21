using UnityEngine;
using System.Collections;

public class FeverGaugeDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

        ///常にカメラの方向を向くようにする。
        transform.LookAt(Camera.main.transform.position);

        FeverManager.AddScore(3);

        ///FeverScoreの割合分だけ回転させる。
        transform.Rotate(-180 * (FeverManager.FeverScore * 1.0f / FeverManager.MaxFeverScore), 0, 0);

	}
}
