using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DeadAnim : StateMachineBehaviour
{
    private GameManager _gameManager;
    private PanelController _panelController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _gameManager = FindObjectOfType<GameManager>();
        _panelController = FindObjectOfType<PanelController>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.tag != "Player")
        {
            _gameManager.enemiesOnLvl--;
        }
        else
        {
            _panelController.playerDead = true;
            _panelController.OpenClosePanel();
        }

        Destroy(animator.gameObject);
    }
}
