using UnityEngine;
using System.Collections;

public class BabbleMover : MonoBehaviour {

    private const float MoveValue = 5.0f;

    [SerializeField]
    private GameObject CenterObject = null;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(CenterObject.transform.localPosition, transform.up, MoveValue * Time.deltaTime);
    }
}
