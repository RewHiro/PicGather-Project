using UnityEngine;
using System.Collections;

public class FairyEating : MonoBehaviour {

    FairyMover Move = null;

    float Scale = 0.5f;
    float ScaleTime = 5.0f;
    const float MaxScale = 1;

	// Use this for initialization
	void Start () {
        Move = GetComponent<FairyMover>();

	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.localScale.x >= MaxScale)
        {
            Move.SetStateAbsorption();
        }
	}

    void OnCollisionStay(Collision collision)
    {
        if (Move.IsMove) return;

        if (collision.gameObject.name == "Fruit")
        {
            Scale += 0.1f;
            iTween.ScaleTo(gameObject,new Vector3(Scale, Scale, Scale),ScaleTime);

            Destroy(collision.gameObject);
        }

    }
}
