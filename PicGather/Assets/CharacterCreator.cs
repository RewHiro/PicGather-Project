﻿/// ---------------------------------------------------
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
        yield return new WaitForSeconds(4.0f);

        //var ReadPath = Manager.Name + "/" + Manager.ID;
        //var TextureCampus = Resources.Load(ReadPath) as Texture2D;
        //if (!TextureCampus)
        //{
        //    //TextureCampus.LoadImage(LoadBin(Application.dataPath + "/Resources/" + ReadPath + ".png"));
        //}
        var Clone = (GameObject)Instantiate(Prefab, new Vector3(0, 100, 0), Prefab.transform.rotation);
        Clone.transform.parent = Manager.transform;
        Clone.name = Prefab.name;
        //Clone.renderer.material.mainTexture = TextureCampus;
        Clone.renderer.material.mainTexture = Manager.CampusTexture;

        Manager.NoneState();

    }

    byte[] LoadBin(string path)
    {
        //FileStream fs = new FileStream(path, FileMode.Open);
        //BinaryReader br = new BinaryReader(fs);
        //byte[] buf = br.ReadBytes((int)br.BaseStream.Length);
        //br.Close();
        //return buf;
        return null;
    }
}
