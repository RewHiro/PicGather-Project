using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

    [SerializeField]
    private GameObject EffectPrefab = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(TouchManager.IsTouching(this.gameObject))
        {
            Instantiate(EffectPrefab, this.gameObject.transform.position, Quaternion.identity);
        }

	}
}
