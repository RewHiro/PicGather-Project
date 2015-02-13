using UnityEngine;
using System.Collections;

public class FairyAppear : MonoBehaviour {

    GameObject Tree = null;
    Vector3 ArrivalPos = Vector3.zero;
    
    public bool IsStop {get;private set;}

    const float DownSpeed = -1.0f;
    const float ArrivalTime = 6.0f;

	void Start () 
    {
        Tree = GameObject.Find("Tree");
        
        SetArrivalPos();
	}

    /// <summary>
    /// 目的地を設定する。
    /// </summary>
    void SetArrivalPos()
    {
        var scale = Tree.transform.lossyScale * 3;
        var value = Random.Range(0, 100);
        var randomY = Random.Range(-Screen.height/2, Screen.height/2);
        var randomZ = Random.Range(-scale.z * 10, scale.z * 10);

        var appearancePos = value > 50 ?
            Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width/3, randomY, randomZ)) :
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/3, randomY, randomZ));

        var treePos = Tree.transform.position;
        transform.position = Camera.main.WorldToScreenPoint(appearancePos);
        transform.LookAt(treePos);

        ArrivalPos = treePos + new Vector3(0, Random.Range(-scale.y / 2, scale.y / 2));
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
            enabled = false;
        }
    }
}
