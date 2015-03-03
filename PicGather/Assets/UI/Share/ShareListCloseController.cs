using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShareListCloseController : MonoBehaviour {

    GameObject ShareList = null;
    Button CloseButton = null;

	// Use this for initialization
	void Start () {
        ShareList = GameObject.Find("PictureSaveUI");
        CloseButton = GetComponent<Button>();
        CloseButton.onClick.AddListener(None);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void None()
    {
        ModeManager.ChangeGameMode();
        Destroy(ShareList);
    }
}
