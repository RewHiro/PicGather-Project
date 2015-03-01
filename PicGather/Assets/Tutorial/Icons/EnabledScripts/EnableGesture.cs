using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableGesture : MonoBehaviour
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

        if (TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawCloud] &&
            TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawFairy] &&
            TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawLeaf])
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private bool EnableImage()
    {
        if (!TutorialMngr.IsCampusMode) return false;

        if (CCController.CharaManager != null)
        {
            if (!TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawCloud] &&
                CCController.CharaManager.Name == "Cloud")
            {
                return true;
            }

            if (!TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawFairy] &&
                CCController.CharaManager.Name == "Fairy")
            {
                return true;
            }

            if (!TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawLeaf] &&
                CCController.CharaManager.Name == "Leaf")
            {
                return true;
            }
        }

        return false;
    }
}
