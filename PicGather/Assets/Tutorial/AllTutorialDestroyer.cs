using UnityEngine;
using System.Collections;

public class AllTutorialDestroyer : MonoBehaviour {

    public void DestroyAllTutorial()
    {
        var Tutorials = GameObject.FindGameObjectsWithTag("Tutorial");
        foreach(var tutorial in Tutorials)
        {
            Destroy(tutorial);
        }
    }

}
