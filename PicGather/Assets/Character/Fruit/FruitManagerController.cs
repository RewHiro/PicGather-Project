using UnityEngine;
using System.Collections;

public class FruitManagerController : CharacterManager {

    FruitCreator Creator = null;

    // Use this for initialization
    void Awake()
    {
        Name = "Fruit";
        Init();

        Creator = GetComponent<FruitCreator>();
    }

    /// <summary>
    /// 子オブジェクトを生成
    /// </summary>
    public void ChildrenCreate(Vector3 pos)
    {
        var clone = Creator.Create(pos);

        CreateChildrenDataSave(clone);
        ChildrensDataSave();
    }
}
