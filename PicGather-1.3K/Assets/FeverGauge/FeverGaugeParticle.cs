using UnityEngine;
using System.Collections;

public class FeverGaugeParticle : MonoBehaviour {

    void Start()
    {
        Stop();
    }

    public void Stop()
    {
        if (!GetComponent<ParticleSystem>().isPlaying) return;

        GetComponent<ParticleSystem>().Stop(false);
    }

    public void Play()
    {
        GetComponent<ParticleSystem>().Play(true);
    }
}
