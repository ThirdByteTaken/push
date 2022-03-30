using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HelperController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void MoveForward()
    {
        anim.enabled = true;
    }

    public void StandStill()
    {
        anim.enabled = false;
    }

}
