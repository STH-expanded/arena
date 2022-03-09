using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkbackState : State
{
    public AttackState attackState;
    public CombatStanceState combatStanceState;
    public StrafeState strafeState;
    public int framecount = 0;
    private Vector3 newPos = new Vector3(0, 0, 0);
    public override State Tick(EnemyManager enemyManager, UnitStatistics enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        attackState.hasPerformedAttack = false;
        enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);

        if (framecount < 2)
        {
            newPos = (enemyManager.transform.position + enemyManager.transform.forward * -5f) * 2;
        }

        enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
        if (enemyManager.transform.position.x > -10 && enemyManager.transform.position.x < 10 && enemyManager.transform.position.z > -10 && enemyManager.transform.position.z < 10)
        {
            //enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + enemyManager.transform.forward * -5f * Time.deltaTime);
            enemyManager.enemyRigidBody.MovePosition(Vector3.Lerp(enemyManager.transform.position, newPos, 0.5f * Time.deltaTime));
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
