using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareToJumpAnim : StateMachineBehaviour
{
    private PlayerController playerController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = animator.GetComponent<PlayerController>();
        playerController.checkYAxis = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController.StartCoroutine(playerController.JumpCourutine());
    }
}
