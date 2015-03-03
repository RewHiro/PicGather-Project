using UnityEngine;
using System.Collections;

public class CelestialBodyTouchEffecter : MonoBehaviour {

    [SerializeField]
    GameObject EffectPrefab = null;

    public void TouchEvent(GameObject button)
    {
        var clone = (GameObject)Instantiate(EffectPrefab, button.transform.position, Quaternion.identity);
        clone.transform.parent = transform;
    }
}
