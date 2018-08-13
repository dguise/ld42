using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorRandomOffset : MonoBehaviour
{
    void Start()
    {
        var anim = GetComponent<Animator>();

        //Set a random part of the animation to start from
        var randomIdleStart = Random.Range(0, anim.GetCurrentAnimatorStateInfo(0).length);
        anim.Play(0, 0, randomIdleStart);
    }
}
