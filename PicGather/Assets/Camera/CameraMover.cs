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

    /// <summary>
    /// カメラを動かすかどうか
    /// </summary>
    private bool CanMoveCamera = false;

	// Update is called once per frame
	void Update () {
        if (ModeManager.IsDrawingMode) return;

        if (Input.touchCount > 0) TurnCamera();
	}

    /// <summary>
    /// 何にもタッチしていない（＝背景にRayが当たっている）ならカメラを回転させる。
    /// </summary>
    private void TurnCamera()
    {
        if (IsTouchingNothing() && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CanMoveCamera = true;
        }

        if (CanMoveCamera && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Camera.main.transform.RotateAround(CenterObject.localPosition, transform.up, MoveValue * Input.GetTouch(0).deltaPosition.x);

            BblDestroyer.DestroyAllBabbles();
        }

        if (!IsTouchingNothing()) CanMoveCamera = false;


    }

    /// <summary>
    /// 何とも当たっていないかどうかを判断する
    /// </summary>
    /// <returns>当たっている...true 当たっている...false</returns>
    private bool IsTouchingNothing()
    {
        var objects = GameObject.FindObjectsOfType<GameObject>();

        foreach(var obj in objects)
        {
            if (TouchManager.IsTouching(obj)) return false;
        }

        var babbles = GameObject.FindGameObjectsWithTag("Babble");


        foreach(var babble in babbles)
        {
            var PositionInScreen = new Vector3(babble.transform.position.x, babble.transform.position.y);
            PositionInScreen = Camera.main.WorldToScreenPoint(PositionInScreen);
            var DistanceX = PositionInScreen.x - Input.GetTouch(0).position.x;
            var DistanceY = PositionInScreen.y - Input.GetTouch(0).position.y;

            var DistanceXY = Mathf.Sqrt(DistanceX * DistanceX + DistanceY * DistanceY);

            if (DistanceXY < BabbleMover.BabbleRadius) return true;

        }

        return true;
    }

}

