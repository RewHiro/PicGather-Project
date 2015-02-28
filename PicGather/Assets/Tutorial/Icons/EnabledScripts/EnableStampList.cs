﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableStampList : MonoBehaviour {

    private TutorialManager TutorialMngr = null;
    private CampusCaptureController CCController = null;
    private Image ThisImage = null;

    private StampListMover SLMover = null;

    // Use this for initialization
    void Start()
    {
        CCController = FindObjectOfType<CampusCaptureController>();
        TutorialMngr = FindObjectOfType<TutorialManager>();
        ThisImage = GetComponent<Image>();
        SLMover = FindObjectOfType<StampListMover>();
    }


    // Update is called once per frame
    void Update()
    {
        ThisImage.enabled = EnableImage();

        if(TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.SelectStampList])
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private bool EnableImage()
    {
        
        if (TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.DrawLeaf] &&
            !TutorialMngr.AlreadyEndedList[(int)TutorialManager.TutorialList.SelectStampList] &&
            SLMover.State == StampListMover.STATE.Close)
        {
            return true;
        }

        return false;
    }
}
