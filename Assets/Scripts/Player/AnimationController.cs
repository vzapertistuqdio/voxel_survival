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

    public void SetMoveState(bool val)
        => anim.SetBool("isMove",val);

}
