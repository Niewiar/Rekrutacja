using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnim : StateMachineBehaviour
{
    PlayerCombat playerCombat;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCombat = animator.GetComponent<PlayerCombat>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCombat.atackTrigger.SetActive(false);
        playerCombat.playerAttacking = false;
    }
}
