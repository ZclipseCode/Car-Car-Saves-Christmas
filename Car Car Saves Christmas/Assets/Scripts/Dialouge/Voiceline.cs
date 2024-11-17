using System;
using UnityEngine;

[Serializable]
public class Voiceline
{
    public AudioClip clip;
    public Animator animator;

    public Voiceline(AudioClip clip, Animator animator)
    {
        this.clip = clip;
        this.animator = animator;
    }
}
