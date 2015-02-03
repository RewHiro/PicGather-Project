using UnityEngine;
using System.Collections;

public class FairyAppear : MonoBehaviour {

    GameObject Tree = null;
    Vector3 ArrivalPos = Vector3.zero;
    bool IsStop = false;

    const float DownSpeed = -1.0f;
    const float ArrivalTime = 6.0f;

	void Start () {
        SetArrivalPos();
	}

    /// <summary>
    /// 目的地を設定する。
    /// </summary>
    void SetArrivalPos()
    {
        Tree = GameObject.Find("Tree");

        var Scale = Tree.transform.lossyScale * 3;
        var Value = Random.Range(0, 100);
        var RandomY = Random.Range(-Screen.height/2, Screen.height/2);
        var RandomZ = Random.Range(-Scale.z * 10, Scale.z * 10);

        var AppearancePos = Value > 50 ?
            Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width/3, RandomY, RandomZ)) :
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/3, RandomY, RandomZ));

        transform.position = Camera.main.WorldToScreenPoint(AppearancePos);

        ArrivalPos = Tree.transform.position + new Vector3(0, Random.Range(-Scale.y / 2, Scale.y / 2));
    }


	// Update is called once per frame
	void Update () {
        if (IsStop) return;

        iTween.MoveUpdate(gameObject, iTween.Hash("position", ArrivalPos,
                        "time", ArrivalTime, "easetype", iTween.EaseType.easeInOutExpo));

	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == Tree.name)
        {
            IsStop = true;
        }
    }
}
