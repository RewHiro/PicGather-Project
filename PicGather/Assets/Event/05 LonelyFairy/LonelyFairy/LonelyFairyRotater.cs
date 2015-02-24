﻿using UnityEngine;
using System.Collections;

public class LonelyFairyRotater : MonoBehaviour {

    /// <summary>
    /// 振り向くのにかかる時間
    /// </summary>
    const float ArrivalTime = 0.1f;

	// Use this for initialization
	void Start () {
        transform.forward = Camera.main.transform.forward;

	}
	
	// Update is called once per frame
	void Update () {
        iTween.LookTo(gameObject, Camera.main.transform.position, ArrivalTime);
	}
}