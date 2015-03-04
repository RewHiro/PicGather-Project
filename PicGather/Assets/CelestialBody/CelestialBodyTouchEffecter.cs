using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CelestialBodyTouchEffecter : MonoBehaviour {

    [SerializeField]
    GameObject EffectPrefab = null;

    [SerializeField]
    SoundEffectPlayer Player = null;

    [SerializeField]
    List<string> SoundResName = new List<string>();

    public void TouchEvent(GameObject button)
    {
        var clone = (GameObject)Instantiate(EffectPrefab, button.transform.position, Quaternion.identity);
        clone.transform.parent = transform;

        var resName = Random.Range(0, SoundResName.Count);
        Player.Play(SoundResName[resName]);
    }
}
