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
	void Awake () {

        Name = "Fairy";
        Init();
	}

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// テンプレート(Sample)を設定する
    /// </summary>
    public override void SetTemplate()
    {
        Template.SetDoubleSprite(TemplateSprite);
    }
}
