using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableSaveButton : MonoBehaviour
{
    private CampusCaptureController CCController = null;
    private Image ThisImage = null;
    // Use this for initialization
    void Start()
    {
        CCController = FindObjectOfType<CampusCaptureController>();
        ThisImage = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        ThisImage.enabled = EnableImage();

    }

    /// <summary>
    /// 描画する条件が満たされているか
    /// </summary>
    /// <returns>満たしている...true 満たしていない...false</returns>
    private bool EnableImage()
    {
        if (CCController.CharaManager != null)
        if (CCController.CharaManager.Name == "Leaf" || CCController.CharaManager.Name == "Fairy" || CCController.CharaManager.Name == "Cloud")
        {
            return true;
        }

        return false;
    }
}
