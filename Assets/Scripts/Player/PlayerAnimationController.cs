using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour, IAnimation
{
    [SerializeField]
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();   
    }

    public void MoveAnim(float parameter)
    {
        anim.SetFloat("Speed", Mathf.Abs(parameter));
    }

    public void MeleeAnim(string name)
    {
        anim.SetTrigger(name);
    }

    public void RangeAnim()
    {
        anim.SetTrigger("IsShooting");
    }
}
