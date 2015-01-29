/// ---------------------------------------------------
/// date ： 2015/01/28    
/// brief ： キャラクターを生成する
/// author ： Yamada Masamistu
/// ---------------------------------------------------

using UnityEngine;
using System.Collections;

public class CharacterCreator : MonoBehaviour {

    [SerializeField]
    GameObject Prefab = null;

    [SerializeField]
    CharacterManager Manager = null;

    void Update()
    {
        if (!Manager.IsCreate) return;

        StartCoroutine("Create");

        Manager.Created();
    }

    /// <summary>
    /// 少し待ってから生成するようにする
    /// もし、Resourcesで読み込みが失敗した場合は絶対パスで取得するようにしている。
    /// </summary>
    /// <returns></returns>
    IEnumerator Create()
    {
        yield return new WaitForSeconds(3.0f);

        var ReadPath = Manager.Name + "/" + Manager.ID;
        var TextureCampus = Resources.Load(ReadPath) as Texture2D;
        var Clone = (GameObject)Instantiate(Prefab, new Vector3(0, 100, 0), Prefab.transform.rotation);
        Clone.name = Prefab.name;
        Clone.renderer.material.mainTexture = TextureCampus;

        Manager.NoneState();

    }

}
