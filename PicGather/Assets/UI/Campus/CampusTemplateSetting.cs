
/// ---------------------------------------------------
/// date ： 2015/01/22 
/// brief ： キャンパスのテンプレートを設定する
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CampusTemplateSetting : MonoBehaviour {

    [SerializeField]
    Sprite NonSelectSprite = null;

    [SerializeField]
    GameObject FrontPrefab = null;

    GameObject Clone = null;
    Image TemplateImage = null;
    public bool IsSelect { get; private set; }

	// Use this for initialization
	void Start () {
        TemplateImage = GetComponent<Image>();
        NonSelect();
	}

    /// <summary>
    /// Spriteを設定する。
    /// </summary>
    /// <param name="templateSprite"></param>
    public void SetSprite(Sprite templateSprite)
    {
        TemplateImage.sprite = templateSprite;
        IsSelect = true;
        DestroyFront();
    }
    
    /// <summary>
    /// Spriteを設定する。
    /// </summary>
    /// <param name="templateSprite"></param>
    public void SetDoubleSprite(Sprite templateSprite)
    {
        TemplateImage.sprite = templateSprite;
        Clone = (GameObject)Instantiate(FrontPrefab,transform.position,Quaternion.identity);
        Clone.transform.parent = transform;
        iTween.ScaleTo(Clone, new Vector3(1, 1, 1), 0);
        Clone.renderer.sortingLayerName = "CampusFront";
        Clone.renderer.sortingOrder = 10000000;
        IsSelect = true;
    }
    

    /// <summary>
    /// 選ばれているフラグを消す。
    /// </summary>
    public void NonSelect()
    {
        TemplateImage.sprite = NonSelectSprite;
        IsSelect = false;
        DestroyFront();
    }

    void DestroyFront()
    {
        if (Clone)
        {
            Destroy(Clone);
        }
    }
}
