using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShareListCloseController : MonoBehaviour {

    GameObject ShareList = null;
    Button CloseButton = null;
    CaptureController Capture = null;

	// Use this for initialization
	void Start () {
        ShareList = GameObject.Find("PictureSaveUI");
        Capture = GameObject.FindObjectOfType(typeof(CaptureController)) as CaptureController;
        CloseButton = GetComponent<Button>();
        CloseButton.onClick.AddListener(None);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void None()
    {
        Capture.ButtonEnable();
        ModeManager.ChangeGameMode();
        Destroy(ShareList);
    }
}
