using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnim : StateMachineBehaviour
{
    private EnemieAi _enemieAi;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemieAi = animator.GetComponent<EnemieAi>();
        if (Vector2.Distance(animator.transform.position, _enemieAi.playerTransform.position) < 1)
        {
            _enemieAi.targetHit.collider.GetComponent<PlayerCombat>().TakeDamage();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_enemieAi.playerTransform != null && Vector2.Distance(animator.transform.position, _enemieAi.playerTransform.position) < 1)
        {
            _enemieAi.CheckCanAttack();
        }
        else
        {
            _enemieAi.enemyState = EnemyStates.Patrol;
        }
    }
}
