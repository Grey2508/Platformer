using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchAndPlay : MonoBehaviour
{
    public AudioSource TargetSound;

    public float MinPitch = 0.8f;
    public float MaxPitch = 1.2f;

    public bool PlayOnAwake = false;
    public float Lifetime = 0;

    private void Start()
    {
        if (PlayOnAwake)
            Play();

        if (Lifetime > 0)
            Destroy(gameObject, Lifetime);
    }

    public void Play()
    {
        TargetSound.pitch = Random.Range(MinPitch, MaxPitch);
        TargetSound.Play();
    }

    public void Stop()
    {
        TargetSound.Stop();
    }
}
