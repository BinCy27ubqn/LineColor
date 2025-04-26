using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance;

    public Animator chessAnimation;
    public ParticleSystem coinParticleSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayAnim(Animator anim)
    {
        anim.Play("Open");
        coinParticleSystem.Play();
    }
}
