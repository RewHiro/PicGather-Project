/// ---------------------------------------------------
/// date ： 2015/01/25 
/// brief ： シェアリストを生成する。(表示する)
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShareListCreator : MonoBehaviour {

    [SerializeField]
    GameObject ShareListPrefab = null;

    GameObject ShareList = null;

    Button ClickButton = null;

	// Use this for initialization
	void Start () {
        ClickButton = GetComponent<Button>();
        ClickButton.onClick.AddListener(Create);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Create()
    {
        if (ModeManager.IsResetMode) return;
        if (ShareList) return;

        StartCoroutine("WaitCreate");
    }

    IEnumerator WaitCreate()
    {
        yield return new WaitForEndOfFrame();

        ShareList = (GameObject)Instantiate(ShareListPrefab, Vector3.zero, Quaternion.identity);
        ShareList.name = ShareListPrefab.name;
    }
}
