using UnityEngine;
using System.Collections;

public class Cleaner : MonoBehaviour {

    public void ClearGameObject(string nameTag)
    {
        var clones = GameObject.FindGameObjectsWithTag(nameTag);
        if (clones == null) return;
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
}
