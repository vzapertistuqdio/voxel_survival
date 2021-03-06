using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private float smoothDamp = 0.1f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeMoveZAnimation(float deltaY)
    {
        anim.SetFloat("RunZ", deltaY,smoothDamp,Time.deltaTime);
    }

    public void ChangeMoveXAnimation(float deltaY)
    {
        anim.SetFloat("RunX", deltaY, smoothDamp, Time.deltaTime);
    }
}
