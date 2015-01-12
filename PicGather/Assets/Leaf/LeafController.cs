/// ---------------------------------------------------
/// date ： 2015/01/12 
/// brief ： 葉っぱのビルボード化
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class LeafController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back);
        transform.rotation *= Quaternion.Euler(0, 180, 0);
	}
}
