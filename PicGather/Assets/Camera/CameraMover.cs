using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

    [SerializeField]
    private Transform CenterObject = null;

    [SerializeField]
    private float MoveValue = 1.0f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Camera.main.transform.RotateAround(CenterObject.localPosition, transform.up, MoveValue * Input.GetTouch(0).deltaPosition.x);
        }
	}
}
