using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorInt : StateMachineBehaviour
{
    public string targetInt;
    public int value;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger(targetInt, value);
    }
}
