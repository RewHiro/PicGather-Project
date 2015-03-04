using UnityEngine;
using System.Collections;

public class FeverGaugeParticle : MonoBehaviour {

    void Start()
    {
        Stop();
    }

    public void Stop()
    {
        particleSystem.Stop(false);
    }

    public void Play()
    {
        particleSystem.Play(true);
    }
}
