using UnityEngine;
using System.Collections;

public class CloudCreator : MonoBehaviour {

    [SerializeField]
    GameObject Children = null;
    float Count = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        //  デバッグ
        Count += Time.deltaTime;
        if (Count >= 10)
        {
            var Clone = (GameObject)Instantiate(Children, new Vector3(0,100,0), Children.transform.rotation);
            Clone.name = Children.name;
            Clone.renderer.sortingLayerName = "Cloud";
            Count = 0;
        }
	}
}
