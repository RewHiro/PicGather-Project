/// ---------------------------------------------------
/// date ： 2015/02/19  
/// brief ： 画像のアニメーション
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageAnimationController : MonoBehaviour {

    [SerializeField]
    List<Sprite> CharacterSprite = new List<Sprite>();

    [SerializeField]
    float ChangeTime = 0.5f;

    Image CharacterImage = null;
    float Count = 0;
    int Index = 0;

	// Use this for initialization
	void Start () {
        CharacterImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        ChangeSprite();
	}

    /// <summary>
    /// スプライトを切り替える
    /// </summary>
    void ChangeSprite()
    {
        Count += Time.deltaTime;
        if (Count >= ChangeTime)
        {
            Count = 0;
            if (!IsRangeOver())
            {
                Index++;
            }
            CharacterImage.sprite = CharacterSprite[Index];
        }
    }

    /// <summary>
    /// Indexの範囲制御
    /// </summary>
    bool IsRangeOver()
    {
        if (Index >= CharacterSprite.Count - 1)
        {
            Index = 0;
            return true;
        }

        return false;
    }
}
