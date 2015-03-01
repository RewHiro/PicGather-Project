using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GestureMover : MonoBehaviour {


    private const float LoopTime = 2.5f;

    private float NowAnimetionTime = 0.0f;

    private Vector3 PositionInScreen = Vector3.zero;

    private Vector3 StartScreenPosition = Vector3.zero;

    private Vector3 Velocity = Vector3.zero;

    private RectTransform rect = null;

    private Image ThisImage = null;

	// Use this for initialization
	void Start () {
        ThisImage = GetComponent<Image>();
        rect = transform as RectTransform;
        StartScreenPosition = PositionInScreen = Camera.main.WorldToScreenPoint(transform.position);
        ResetVelocity();

    }
	
	// Update is called once per frame
	void Update () {

        if (ThisImage.enabled)
        {
            Move();
        }
        else
        {
            NowAnimetionTime = 0.0f;
            PositionInScreen = StartScreenPosition;
            ResetVelocity();
        }
	}

    private void ResetVelocity()
    {
        Velocity.x = Screen.width / 5 * 2;
        Velocity.y = Screen.height / LoopTime * 2;
    }

    private void Move()
    {
        if (NowAnimetionTime >= LoopTime)
        {
            NowAnimetionTime = 0.0f;
            PositionInScreen = StartScreenPosition;
            ResetVelocity();
        }

        NowAnimetionTime += Time.deltaTime;

        PositionInScreen += Velocity * Time.deltaTime;

        Bounding();

        transform.position = Camera.main.ScreenToWorldPoint(PositionInScreen);
    }

    private void Bounding()
    {
        var TopLimit = Screen.height * 3 / 5;
        var BottomLimit = Screen.height * 1 / 5;
        if (PositionInScreen.y > TopLimit)
        {
            PositionInScreen.y = TopLimit;
            Velocity.x *= -0.5f;
            Velocity.y *= -1;
        }

        if (PositionInScreen.y < BottomLimit)
        {
            PositionInScreen.y = BottomLimit;
            Velocity.x *= -2.0f;
            Velocity.y *= -1;
        }

    }

}
