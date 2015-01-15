using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームオブジェクトを削除する機能
/// </summary>

public class LineClearner : MonoBehaviour
{

    public void ClearLineByTag()
    {
        var clones = GameObject.FindGameObjectsWithTag("Line");
        if (clones == null) return;
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
}
