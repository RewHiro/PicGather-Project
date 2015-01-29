using UnityEngine;
using System.Collections;

public class FairyAppear : MonoBehaviour {

    [SerializeField]
    string TreeName = "Tree";

    bool IsMove = true;

    const float DownSpeed = -1.0f;

	// Use this for initialization
	void Start () {
        var TreeObject = GameObject.Find(TreeName);
        var Position = TreeObject.transform.position;
        var Scale = TreeObject.transform.lossyScale*3;

        var AppearancePosX = Position.x + Random.Range(-Scale.x, Scale.x);
        var AppearancePosZ = Position.z + Random.Range(-Scale.z, Scale.z);

        transform.position = new Vector3(AppearancePosX, Position.y + 10, AppearancePosZ);
	}
	
	// Update is called once per frame
	void Update () {
        if (!IsMove) return;

        transform.Translate(new Vector3(0, DownSpeed * Time.deltaTime, 0));
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == TreeName)
        {
            IsMove = false;
        }
    }
}
