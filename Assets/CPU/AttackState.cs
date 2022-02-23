using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public CombatStanceState combatStanceState;
    public PursueTargetState pursueTargetState;
    public EnemyAttackAction currentAttack;
    public StrafeState strafeState;
    public WalkbackState walkbackState;
    public int framecount = 0;

    public bool hasPerformedAttack = false;
    public override State Tick(EnemyManager enemyManager, UnitStatistics enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if (!hasPerformedAttack)
        {
            if (distanceFromTarget < 1)
            {
                AttackTarget(enemyAnimatorManager, enemyManager);
                enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            }
            else
            {
                if (framecount < 60)
                {
                    enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
                    enemyAnimatorManager.animator.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                    framecount++;
                    return this;
                }
                else
                {
                    framecount = 0;
                    return strafeState;
                }
            }
        }

        return strafeState;
    }

    private void AttackTarget(EnemyAnimatorManager enemyAnimatorManager, EnemyManager enemyManager)
    {
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        hasPerformedAttack = true;
    }


}
