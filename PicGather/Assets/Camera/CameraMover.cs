using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

   
    /// <summary>
    /// カメラをY軸回転させる中心となるGameObject
    /// </summary>
    [SerializeField]
    private Transform CenterObject = null;

    /// <summary>
    /// カメラの移動量
    /// </summary>
    [SerializeField]
    private float MoveValue = 1.0f;

    /// <summary>
    /// BabbleDestroyerクラスのDestroyAllBabblesを呼ぶために用意する
    /// </summary>
    private BabbleDestroyer BblDestroyer = null;

    // Use this for initialization
	void Start () {
        BblDestroyer = GetComponent<BabbleDestroyer>();
	}

 
	// Update is called once per frame
	void Update () {
        if (ModeManager.IsDrawingMode) return;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Camera.main.transform.RotateAround(CenterObject.localPosition, transform.up, MoveValue * Input.GetTouch(0).deltaPosition.x);

            BblDestroyer.DestroyAllBabbles();
        }
	}
}
