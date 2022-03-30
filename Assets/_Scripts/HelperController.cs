using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class HelperController : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    Material mat_Stranger;


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

    public void GiveUp()
    {
        anim.enabled = true;
        anim.SetTrigger("Bail");
        meshRenderer.material = mat_Stranger;
    }

}
