using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OpenOurEyesMover : MonoBehaviour {

    [SerializeField]
    GameObject GraphicEffectPrefab = null;

    [SerializeField]
    List<Texture>textures = new List<Texture>();

    [SerializeField]
    GameObject FoundSE = null;

    public enum State
    {
        APPEARANCE,
        HIDE,
        FOUND,
    };

    public State state { get; private set; }
    float RotationAngle = 0;
    float jumpAnimation = 0;
    float count = 0;

	// Use this for initialization
	void Start () {
        state = State.APPEARANCE;
        renderer.material.mainTexture = textures[0];
	}
	
	// Update is called once per frame
	void Update () {

        Appearance();
        Hide();
	}

    void Appearance()
    {

        if (state != State.APPEARANCE) return;
        iTween.MoveTo(gameObject,
            iTween.Hash("position", Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 - Screen.height * 0.2f, 2 - Camera.main.GetComponent<CameraMover>().MoveRadius)),
            "time", 7.0f,
            "easetype", iTween.EaseType.easeOutQuad));


        AppearanceToHide();

    }

    void Hide()
    {
        if (state != State.HIDE) return;
        HideMove();
        OnMouseCollision();
    }

    void AppearanceToHide()
    {
        count += Time.deltaTime;
        if (count < 7.0f) return;
        state = State.HIDE;
        renderer.material.mainTexture = textures[1];
    }

    void OnMouseCollision()
    {
        if (!(TouchManager.IsMouseButtonDown(gameObject)|| TouchManager.IsTouching(gameObject))) return;
        state = State.FOUND;
        Instantiate(GraphicEffectPrefab, gameObject.transform.position, Quaternion.identity);
        Instantiate(FoundSE);
        Destroy(gameObject);
        GameObject.Find("SunCharacter").GetComponent<Image>().enabled = true;
    }

    void HideMove()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        jumpAnimation += 1;
        if (Screen.width / 2 - 0.01f > pos.x)
        {
            RotationAngle += 0.01f;

        }
        else if (Screen.width / 2 + 0.01f < pos.x)
        {
            RotationAngle += -0.01f;
        }
        transform.localPosition = new Vector3(
            Mathf.Sin(RotationAngle) * 2,
            transform.localPosition.y + Mathf.Sin(jumpAnimation) * 0.05f,
            Mathf.Cos(RotationAngle) * 2);
    }
}