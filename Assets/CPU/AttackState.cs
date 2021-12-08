using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public CombatStanceState combatStanceState;
    public PursueTargetState pursueTargetState;
    public EnemyAttackAction currentAttack;
    public WalkbackState walkbackState;

    public bool hasPerformedAttack = false;
    public override State Tick(EnemyManager enemyManager, UnitStatistics enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if (distanceFromTarget > 3)
        {
            return pursueTargetState;
        }

        if (!hasPerformedAttack)
        {
            AttackTarget(enemyAnimatorManager, enemyManager);
        }

        if (hasPerformedAttack && enemyManager.currentRecoveryTime > 1)
        {
            return this;
        } else if (hasPerformedAttack && enemyManager.currentRecoveryTime <= 1){
            hasPerformedAttack = false;
            return walkbackState;
        }

        return walkbackState;
    }

    private void AttackTarget(EnemyAnimatorManager enemyAnimatorManager, EnemyManager enemyManager)
    {
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        hasPerformedAttack = true;
    }


}
