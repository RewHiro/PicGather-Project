﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableFairyButton : MonoBehaviour
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

        if(TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawFairy])
        {
            Destroy(transform.parent.gameObject);
        }

    }

    private bool EnableImage()
    {
        if (TutorialMngr.IsCampusMode &&
            TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawCloud] &&
            !TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawFairy] &&
            (CCController.CharaManager == null || CCController.CharaManager.Name != "Fairy"))
        {
            return true;
        }

        return false;
    }
}
