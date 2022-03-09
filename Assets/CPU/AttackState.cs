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
            if (distanceFromTarget < 1.5f)
            {
                enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
                enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + Vector3.Normalize(targetDirection) * 10f * Time.deltaTime);
                enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                AttackTarget(enemyAnimatorManager, enemyManager);
            }
            else
            {
                if (framecount < 80)
                {
                    enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
                    enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + Vector3.Normalize(targetDirection) * 10f * Time.deltaTime);
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

        return walkbackState;
    }

    private void AttackTarget(EnemyAnimatorManager enemyAnimatorManager, EnemyManager enemyManager)
    {
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
        enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
        hasPerformedAttack = true;
    }


}
