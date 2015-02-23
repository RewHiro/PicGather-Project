/// ---------------------------------------------------
/// date ： 2015/02/17  
/// brief ： 木を大きくする処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class TreeScaling : MonoBehaviour {

    [SerializeField]
    float AddScale = 1.0f;

    [SerializeField]
    float ScaleToTime = 3.0f;

    float Scale = 0;

    TreeChanger Changer = null;

	// Use this for initialization
	void Start () {
        Scale = transform.lossyScale.x;
        Changer = GetComponent<TreeChanger>();
	}
	
    void Update()
    {
        if (!Changer.IsScaling) return;
        if (ModeManager.IsFerverMode) return;

        Scale += AddScale;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(Scale, Scale, Scale),
                        "time", ScaleToTime, "easetype", iTween.EaseType.easeInOutExpo));

        Changer.ChangeNormalState();
    }

    IEnumerator Save()
    {
        yield return new WaitForSeconds(ScaleToTime);

        Changer.Save();
    }
}
