/// ---------------------------------------------------
/// date ： 2015/01/12  
/// brief ： 雲オブジェクトの移動処理 / ビルボード処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

    [SerializeField]
    private GameObject CenterObject = null;


    float Radius = 0.0f;
    float Angle = 0.0f;
	
    // Use this for initialization
	void Start () {
        Radius = Random.Range(-7, -6);
	}
	
	void Update () 
    {
        var pos = CenterObject.transform.position;

        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back);

        transform.rotation *= Quaternion.Euler(0, 180, 0);

        transform.position = new Vector3(pos.x + Mathf.Cos(Angle) * Radius,
                                pos.y, pos.z + Mathf.Sin(Angle) * Radius);
        Angle += 0.01f;
	}
}
