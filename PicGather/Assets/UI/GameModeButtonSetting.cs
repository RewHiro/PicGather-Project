using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameModeButtonSetting : MonoBehaviour
{
    Button UIButton = null;

	// Use this for initialization
	void Awake () {
        UIButton = GetComponent<Button>();
    }


    /// <summary>
    /// OnClickを追加する
    /// </summary>
    /// <param name="call"></param>
    public void AddOnClick(UnityEngine.Events.UnityAction call)
    {
        UIButton.onClick.AddListener(call);
    }

	void Update () {
        if (ModeManager.IsGameMode())
        {
            UIButton.enabled = true;
        }
        else
        {
            UIButton.enabled = false;
        }
	}
}
