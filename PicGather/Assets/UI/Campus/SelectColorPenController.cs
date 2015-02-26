using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectColorPenController : MonoBehaviour {

    Image PenImage = null;

    void Start()
    {
        PenImage = GetComponent<Image>();
    }

    public void ChangeColor(Sprite penSprite)
    {
        PenImage.sprite = penSprite;
    }
}
