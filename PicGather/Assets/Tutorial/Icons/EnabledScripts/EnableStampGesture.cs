using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableStampGesture : MonoBehaviour {

    private StampGestureManager StampGestureMngr = null;

    private Image ThisImage = null;
    
    // Use this for initialization
	void Start () {
        StampGestureMngr = FindObjectOfType<StampGestureManager>();
        ThisImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        ThisImage.enabled = StampGestureMngr.EnableImage;

        if(CanDestroy())
        {
            Destroy(transform.parent.gameObject);
        }
	}

    /// <summary>
    /// 破壊するかどうか
    /// </summary>
    /// <returns>破壊する...true 破壊しない...false</returns>
    private bool CanDestroy()
    {
        if (StampGestureMngr.LeafNumber <= 0) return false;

        var nowLeafNumber = GameObject.FindGameObjectsWithTag("Leaf").Length;
        if (StampGestureMngr.LeafNumber < nowLeafNumber)
        {
            return true;
        }

        return false;
    }


}
