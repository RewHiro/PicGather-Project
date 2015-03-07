using UnityEngine;
using System.Collections;

/// <summary>
/// バスケットのソーティング機能
/// </summary>
public class BasketSortingLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("BasketFront").GetComponent<Renderer>().sortingLayerName = "BasketFront";
        GameObject.Find("BasketBack").GetComponent<Renderer>().sortingLayerName = "BasketBack";
	}
}
