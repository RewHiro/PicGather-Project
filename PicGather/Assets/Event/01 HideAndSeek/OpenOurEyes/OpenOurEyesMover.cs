using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenOurEyesMover : MonoBehaviour {

    [SerializeField]
    GameObject GraphicEffectPrefab;

    [SerializeField]
    List<Texture>textures; 

    public enum State
    {
        APPEARANCE,
        HIDE,
        FOUND,
    };

    public State state { get; private set; }
    float RotationAngle = 0;
    float jumpAnimation = 0;

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
            iTween.Hash("position", Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 - Screen.height * 0.2f, 17)),
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
        if (transform.localPosition.y > 0.5f) return;
        state = State.HIDE;
        renderer.material.mainTexture = textures[1];
    }

    void OnMouseCollision()
    {
        if (!TouchManager.IsMouseButtonDown(gameObject)) return;
        state = State.FOUND;
        Instantiate(GraphicEffectPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void HideMove()
    {
        Debug.Log(RotationAngle);
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