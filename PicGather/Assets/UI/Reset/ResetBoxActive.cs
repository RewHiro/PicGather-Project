using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetBoxActive : MonoBehaviour {

    [SerializeField]
    GameObject SelectBox = null;

    Button ResetButton = null;

    void Start()
    {
        ResetButton = GetComponent<Button>();
    }

    void Update()
    {
        if (ModeManager.IsResetMode) return;
        if (ModeManager.IsGameMode) return;
        if (ModeManager.IsShareMode) return;

        SelectBox.SetActive(false);
        ModeManager.ChangeGameMode();
        ResetButton.enabled = true;

    }

    /// <summary>
    /// セレクトボックスをアクティブにする
    /// </summary>
    public void SetActiveSelectBox()
    {
        if (ModeManager.IsShareMode) return;
        if (ModeManager.IsResetMode) return;

        SelectBox.SetActive(true);
        ModeManager.ChangeResetMode();
        ResetButton.enabled = false;
    }

}
