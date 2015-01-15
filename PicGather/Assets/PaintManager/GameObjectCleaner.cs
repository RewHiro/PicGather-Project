using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームオブジェクトを削除する機能
/// </summary>

public class GameObjectCleaner : MonoBehaviour
{

    public void ClearGameObjectByTag(string nameTag)
    {
        var clones = GameObject.FindGameObjectsWithTag(nameTag);
        if (clones == null) return;
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
}
