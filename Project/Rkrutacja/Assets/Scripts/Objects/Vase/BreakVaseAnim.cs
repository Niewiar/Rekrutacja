using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakVaseAnim : StateMachineBehaviour
{
    private Vase _vase;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _vase = animator.GetComponent<Vase>();

        if (!_vase.isLoadSceneVase)
        {
            _vase.GenerateCoins();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_vase.isLoadSceneVase && _vase.sceneIndex > -1)
        {
            _vase.LoadScene(_vase.sceneIndex);
        }
        else if (_vase.isLoadSceneVase && _vase.sceneIndex == -1)
        {
            Application.Quit();
        }
        Destroy(animator.gameObject);
    }
}
