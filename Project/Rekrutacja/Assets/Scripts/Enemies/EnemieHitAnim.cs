using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHitAnim : StateMachineBehaviour
{
    private EnemieAi _enemieAi;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemieAi = animator.GetComponent<EnemieAi>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemieAi.hit = false;
    }
}
