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
    private float MoveValue = 2.0f;

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

        TurnCamera();
	}

    /// <summary>
    /// 何にもタッチしていない（＝背景にRayが当たっている）ならカメラを回転させる。
    /// </summary>
    private void TurnCamera()
    {

        TurnByMouse();

        TurnByTouch();

        StopTurningCamera();
    }

    /// <summary>
    ///タッチもマウス入力もされていなかったらカメラを回せないようにする。
    /// </summary>
    private void StopTurningCamera()
    {
        if (Input.touchCount == 0 && !Input.GetMouseButton(0)) CanMoveCamera = false;

    }


    /// <summary>
    /// マウスによるカメラの移動
    /// </summary>
    private void TurnByMouse()
    {
        if (Input.GetMouseButtonDown(0) && IsTouchingNothing())
        {
            CanMoveCamera = true;
        }

        if (CanMoveCamera && Input.GetMouseButton(0))
        {
            var deltaMouseX = Input.GetAxis("Mouse X");
            Camera.main.transform.RotateAround(CenterObject.localPosition, transform.up, MoveValue * deltaMouseX);

            BblDestroyer.DestroyAllBabbles();
        }

    }

    /// <summary>
    /// タッチによるカメラの移動
    /// </summary>
    private void TurnByTouch()
    {
        if (Input.touchCount > 0)
        {
            if (IsTouchingNothing() && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                CanMoveCamera = true;
            }

            if (CanMoveCamera && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Camera.main.transform.RotateAround(CenterObject.localPosition, transform.up, Input.GetTouch(0).deltaPosition.x);

                BblDestroyer.DestroyAllBabbles();
            }

        }
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
            if (TouchManager.IsMouseButton(obj)) return false;
            if (TouchManager.IsTouching(obj)) return false;
        }

        if (IsBabbleInside(Input.mousePosition)) return false;

        foreach(var touch in Input.touches)
        {
            if (IsBabbleInside(touch.position)) return false;
        }

        return true;
    }
    
    /// <summary>
    /// 引数の座標がシャボン玉内にあるかどうかを返す
    /// </summary>
    /// <param name="point">調べる座標</param>
    /// <returns>内部にある...true 外にある...false</returns>
    private bool IsBabbleInside(Vector2 point)
    {
        var babbles = GameObject.FindGameObjectsWithTag("Babble");

        foreach (var babble in babbles)
        {
            var PositionInScreen = new Vector3(babble.transform.position.x, babble.transform.position.y);
            PositionInScreen = Camera.main.WorldToScreenPoint(PositionInScreen);
            var DistanceX = PositionInScreen.x - point.x;
            var DistanceY = PositionInScreen.y - point.y;

            var DistanceXY = Mathf.Sqrt(DistanceX * DistanceX + DistanceY * DistanceY);

            if (DistanceXY < BabbleMover.BabbleRadius) return true;

        }

        return false;
    }
}

