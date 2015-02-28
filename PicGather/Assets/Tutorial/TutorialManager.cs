using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {

    public enum TutorialList
    {
        NULL = -1,
        SelectCampus ,
        SelectStampList,
        DrawLeaf,
        DrawFairy,
        DrawCloud,
        GUARD
    };

    /// <summary>
    /// 
    /// </summary>
    private bool[] alreadyEndedList = new bool[(int)TutorialList.GUARD];

    public bool[] AlreadyEndedList { 
        get { return this.alreadyEndedList; }
        set { this.alreadyEndedList = value; }
    }

    public bool IsCampusMode = false;

    // Use this for initialization
	void Start () {

        for (int i = 0; i < (int)TutorialList.DrawCloud; i++)
        {
            AlreadyEndedList[i] = false;
        }
    }

    public void AlreadySelectCampus()
    {
        AlreadyEndedList[(int)TutorialList.SelectCampus] = true;  
    }

    public void AlreadySelectStampList()
    {
        AlreadyEndedList[(int)TutorialList.SelectStampList] = true;
    }

    /// Draw関係

    public void AlreadyDrawLeaf()
    {
        AlreadyEndedList[(int)TutorialList.DrawLeaf] = true;
    }

    public void AlreadyDrawFairy()
    {
        AlreadyEndedList[(int)TutorialList.DrawFairy] = true;
    }


    public void AlreadyDrawCloud()
    {
        AlreadyEndedList[(int)TutorialList.DrawCloud] = true;
    }

    public void ChangeState()
    {
        var CCController = FindObjectOfType<CampusCaptureController>();

        if (CCController.CharaManager == null) return;

        switch(CCController.CharaManager.Name)
        {
            case "Leaf":
                AlreadyEndedList[(int)TutorialList.DrawLeaf] = true;
                break;
            case "Cloud":
                AlreadyEndedList[(int)TutorialList.DrawCloud] = true;
                break;
            case "Fairy":
                AlreadyEndedList[(int)TutorialList.DrawFairy] = true;
                break;
            default:
                return;
        }

        return;
    }

    public void ChangeCampusMode(bool _changed)
    {
        var TutorialMngr = FindObjectOfType<TutorialManager>();

        TutorialMngr.IsCampusMode = _changed;
    }

    public void SaveAndChangeCampusMode(bool _changed)
    {
        var TutorialMngr = FindObjectOfType<TutorialManager>();

        var CCController = FindObjectOfType<CampusCaptureController>();

        if (CCController.CharaManager == null) return;

        TutorialMngr.IsCampusMode = _changed;
    }

}
