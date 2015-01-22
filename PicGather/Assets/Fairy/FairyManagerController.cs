/// ---------------------------------------------------
/// date ： 2015/01/14  
/// brief ： 妖精管理クラス
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using System.Collections;

public class FairyManagerController : CharacterManager
{


	// Use this for initialization
	void Start () {
        NonSelect();

        Folder = "Fairy";
        LoadID();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
