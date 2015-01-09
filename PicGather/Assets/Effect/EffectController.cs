using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

    [SerializeField]
    private GameObject GraphicEffectPrefab = null;

    [SerializeField]
    private GameObject SoundEffectPrefab = null;

	// Use this for initialization
	void Start () {
	
	}
	
    bool IsMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                return true;
            }
        }
        return false;
    }

	// Update is called once per frame
	void Update () 
    {
        if (TouchManager.IsTouching(this.gameObject) || IsMouseButtonDown())
        {
            Instantiate(GraphicEffectPrefab, this.gameObject.transform.position, Quaternion.identity);
            Instantiate(SoundEffectPrefab, this.gameObject.transform.position, Quaternion.identity);
        }

	}
}
