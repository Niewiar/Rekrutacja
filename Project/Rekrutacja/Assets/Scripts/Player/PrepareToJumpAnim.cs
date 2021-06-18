using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareToJumpAnim : StateMachineBehaviour
{
    private PlayerController _playerController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController = animator.GetComponent<PlayerController>();
        _playerController.checkYAxis = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerController.StartCoroutine(_playerController.JumpCourutine());
    }
}
