using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableCampusButton : MonoBehaviour
{
    private TutorialManager TutorialMngr = null;
    private Image ThisImage = null;
    // Use this for initialization
    void Start()
    {
        TutorialMngr = FindObjectOfType<TutorialManager>();
        ThisImage = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!EnableImage())
        {
            Destroy(transform.parent.gameObject);
        }

    }
    
    private bool EnableImage()
    {
        if (TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawLeaf] &&
            TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawFairy] &&
            TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawCloud])
        {
            return false;
        }

        return true;
    }
}
