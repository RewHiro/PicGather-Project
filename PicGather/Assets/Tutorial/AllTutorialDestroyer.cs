using UnityEngine;
using System.Collections;

public class AllTutorialDestroyer : MonoBehaviour {

    [SerializeField]
    GameObject SkipButton = null;

    private TutorialManager TutorialMngr = null;

    void Start()
    {
        TutorialMngr = FindObjectOfType<TutorialManager>();

    }

    void Update()
    {
        AlreadyAllTutorialEnded();   
    }

    private void AlreadyAllTutorialEnded()
    {

        foreach(var flag in TutorialMngr.AlreadyEndedList)
        {
            if (!flag) return;
        }

        DestroyAllTutorial();
    }

    public void DestroyAllTutorial()
    {
        var Tutorials = GameObject.FindGameObjectsWithTag("Tutorial");
        foreach(var tutorial in Tutorials)
        {
            Destroy(tutorial);
        }

        Destroy(SkipButton);
    }

}
