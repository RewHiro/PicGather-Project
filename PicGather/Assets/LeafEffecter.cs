using UnityEngine;
using System.Collections;

public class LeafEffecter : MonoBehaviour {

    TitleStartter Startter = null;
    Vector3 Velocity = Vector3.zero;

	// Use this for initialization
	void Start () {

        renderer.material.mainTexture = Resources.Load("Leaf" + "/" + Random.Range(0,3)) as Texture2D;

        Startter = GameObject.FindObjectOfType(typeof(TitleStartter)) as TitleStartter;

        Velocity = new Vector3(Startter.WindDirection, 5, 0);
	}

    float Count = 0;
	
	// Update is called once per frame
	void Update () {
        if (!Startter.IsStart) return;


        transform.Translate(Velocity * Time.deltaTime);

        Count+=0.1f;
        Velocity.y -= Mathf.Sin(Count);
        Velocity.x *= 0.99f;
	}
}
