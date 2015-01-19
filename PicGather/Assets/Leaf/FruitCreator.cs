/// ---------------------------------------------------
/// date ： 2015/01/19 
/// brief ： 木の実を生成
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class FruitCreator : MonoBehaviour
{
    [SerializeField]
    GameObject FruitPrefab = null;

    public void Create()
    {
        var Clone = (GameObject)Instantiate(FruitPrefab, transform.position, FruitPrefab.transform.rotation);
        Clone.name = FruitPrefab.name;
    }

}
