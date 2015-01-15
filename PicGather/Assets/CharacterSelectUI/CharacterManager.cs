using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour
{

    public bool IsSelect { get; protected set; }

    /// <summary>
    /// 選択可能状態に設定する。
    /// </summary>
    public virtual void SetCanSelect()
    {
        IsSelect = true;
    }

    /// <summary>
    /// 選択状態をなくす
    /// </summary>
    public virtual void NonSelect()
    {
        IsSelect = false;
    }
}
