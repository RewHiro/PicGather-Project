using UnityEngine;
using System.Collections;

public class WaterSurfaceMover : MonoBehaviour {

    /// <summary>
    /// 親オブジェクトとの相対的なY軸の距離
    /// </summary>
    [SerializeField]
    private const float RelativeDistanceY = -0.5f;

    [SerializeField]
    private const float MaxHeight = 8;

    private Vector3 DefaultPosition = Vector3.zero;

	// Use this for initialization
	void Start () {

        /// 位置を開始時に初期化する
        this.transform.localPosition = new Vector3(0.0f, RelativeDistanceY, 0.0f);
        DefaultPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
        ///フィーバーゲージの量に比例して高さを調整する
       // transform.position = new Vector3(DefaultPosition.x, DefaultPosition.y + MaxHeight * (FeverManager.FeverScore * 1.0f / FeverManager.MaxFeverScore), DefaultPosition.z);

	}

}
