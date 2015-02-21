using UnityEngine;
using System.Collections;

public class MoonRotation : MonoBehaviour {

    [SerializeField]
    float rotationValue = 0.1f;

    float rotate = 0;
    float swingValue = 0.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        rotate += rotationValue * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, swingValue * Mathf.Sin(rotate)));
	}
}
