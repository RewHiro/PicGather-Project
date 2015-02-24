/// ---------------------------------------------------
/// date ： 2015/02/06 
/// brief ： 果実を登場させる。
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class FruitAppearance : MonoBehaviour {


	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Branch")
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
    }
}

