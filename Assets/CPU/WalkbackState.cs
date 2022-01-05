using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkbackState : State
{
    public AttackState attackState;
    public CombatStanceState combatStanceState;
    public override State Tick(EnemyManager enemyManager, UnitStatistics enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        attackState.hasPerformedAttack = false;

        enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
        enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + enemyManager.transform.forward * -0.5f);

        if (distanceFromTarget > 3)
        {
            return combatStanceState;
        }
        return this;
    }
}
