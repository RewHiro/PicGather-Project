using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

    public static bool IsPhaseTap { get; private set; }
    public static bool IsPhaseSwipe { get; private set; }

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public static bool IsTouching(GameObject gameObject_ )
    {
        IsPhaseTap = IsPhaseSwipe = false;

        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit))
                {
                    if (touch.phase == TouchPhase.Began) IsPhaseTap = true;
                    if (touch.phase == TouchPhase.Moved) IsPhaseSwipe = true;

                    if(hit.collider.gameObject == gameObject_)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

}
