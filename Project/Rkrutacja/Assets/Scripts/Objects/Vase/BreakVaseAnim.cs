using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakVaseAnim : StateMachineBehaviour
{
    private Vase _vase;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _vase = animator.GetComponent<Vase>();
        _vase.GenerateCoins();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Destroy(animator.gameObject);
    }
}
