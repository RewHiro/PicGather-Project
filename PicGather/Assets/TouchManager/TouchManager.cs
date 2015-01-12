using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

    public static bool IsPhaseTap { get; private set; }
    public static bool IsPhaseSwipe { get; private set; }
    public static Vector3 TapPos {get;private set;}

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    static void SetNonPhase()
    {
        IsPhaseTap = IsPhaseSwipe = false;
    }


    static void TouchPhaseJudgment(Touch touch)
    {
        if (touch.phase == TouchPhase.Began) IsPhaseTap = true;
        if (touch.phase == TouchPhase.Moved) IsPhaseSwipe = true;
    }

    public static bool IsTouching(GameObject gameObject_ )
    {
        SetNonPhase();

        if (IsMouseButton(gameObject_)) return true;
        if (IsMouseButtonDown(gameObject_)) return true;

        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit = new RaycastHit();

                if (IsRayCatsHit(ray, hit,touch, gameObject_))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// デバックで使用
    /// マウス左ボタンが押されてるときの処理
    /// Rayを飛ばして当たってたら、trueを返す
    /// </summary>
    /// <returns>当たったかどうか?の判定</returns>
    static bool IsMouseButton(GameObject gameObject_)
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (IsRayCatsHit(ray, hit,gameObject_))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// デバックで使用
    /// マウス左ボタンが押されたときの処理
    /// Rayを飛ばして当たってたら、trueを返す
    /// </summary>
    /// <returns>当たったかどうか?の判定</returns>
    static bool IsMouseButtonDown(GameObject gameObject_)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (IsRayCatsHit(ray, hit, gameObject_))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// RayCastで当たったかどうかの判定
    /// タップした座標を取得する。
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="hit"></param>
    /// <returns>当たったかどうか</returns>
    static bool IsRayCatsHit(Ray ray, RaycastHit hit,GameObject gameObject_)
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject_)
            {
                TapPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// RayCastで当たったかどうかの判定
    /// タップした座標を取得する。
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="hit"></param>
    /// <returns>当たったかどうか</returns>
    static bool IsRayCatsHit(Ray ray, RaycastHit hit,Touch touch, GameObject gameObject_)
    {
        if (Physics.Raycast(ray, out hit))
        {
            TouchPhaseJudgment(touch);

            if (hit.collider.gameObject == gameObject_)
            {
                TapPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                return true;
            }
        }
        return false;
    }
}
