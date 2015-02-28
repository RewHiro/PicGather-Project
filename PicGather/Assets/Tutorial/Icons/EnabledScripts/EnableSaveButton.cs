using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableSaveButton : MonoBehaviour
{
    private TutorialManager TutorialMngr = null;
    private CampusCaptureController CCController = null;
    private Image ThisImage = null;
    // Use this for initialization
    void Start()
    {
        CCController = FindObjectOfType<CampusCaptureController>();
        TutorialMngr = FindObjectOfType<TutorialManager>();
        ThisImage = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        ThisImage.enabled = EnableImage();

    }

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
