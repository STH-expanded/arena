using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkbackState : State
{
    public AttackState attackState;
    public CombatStanceState combatStanceState;
    public StrafeState strafeState;
    public int framecount = 0;
    public override State Tick(EnemyManager enemyManager, UnitStatistics enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        attackState.hasPerformedAttack = false;

        enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
        if (enemyManager.transform.position.x > -10 && enemyManager.transform.position.x < 10 && enemyManager.transform.position.z > -10 && enemyManager.transform.position.z < 10)
        {
            enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + enemyManager.transform.forward * -5f * Time.deltaTime);
        }
        if (framecount > 60)
        {
            framecount = 0;
            return strafeState;
        }
        framecount++;
        return this;
    }
}
