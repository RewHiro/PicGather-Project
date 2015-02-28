using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IconEnable : MonoBehaviour {

    private Image ParentImage = null;

    private Image ThisImage = null;

    void Start()
    {
        ParentImage = transform.parent.transform.parent.GetComponent<Image>();
        ThisImage = GetComponent<Image>();
    }

	// Update is called once per frame
	void Update () {
        if (!ParentImage.enabled)
        {
            ThisImage.enabled = ParentImage.enabled;
        }
	}
}
