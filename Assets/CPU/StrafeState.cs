using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeState : State
{
    public PursueTargetState pursueTargetState;
    public CombatStanceState combatStanceState;
    public WalkbackState walkbackState;
    public AttackState attackState;
    public override State Tick(EnemyManager enemyManager, UnitStatistics enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        attackState.hasPerformedAttack = false;
        if (distanceFromTarget > 5)
        {
            enemyAnimatorManager.animator.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
            return pursueTargetState;
        } else if (distanceFromTarget < 2)
        {
            enemyAnimatorManager.animator.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
            float rand = Random.Range(0f, 1f);
            if (rand > 0.5f)
            {
                return combatStanceState;
            } else
            {
                return walkbackState;
            }
        } else
        {
            enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
            enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            enemyAnimatorManager.animator.SetFloat("Horizontal", 1, 0.1f, Time.deltaTime);
            enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + enemyManager.transform.right * 0.05f);
        }

        return this;
    }
}
