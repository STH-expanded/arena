using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeState : State
{
    public PursueTargetState pursueTargetState;
    public CombatStanceState combatStanceState;
    public WalkbackState walkbackState;
    public AttackState attackState;
    public bool direction;
    public int framecount = 0;
    public override State Tick(EnemyManager enemyManager, UnitStatistics enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        attackState.hasPerformedAttack = false;
        float random = Random.Range(0, 4f);
        if (framecount % 180 == 0)
        {
            if (random < 1.6f)
            {
                return attackState;
            } else if (random >= 1.6f && random < 2f)
            {
                return walkbackState;
            } else
            {
                direction = Random.Range(0, 1f) > 0.5 ? true : false;
            }
        }
        framecount++;
        if (distanceFromTarget > 7)
        {
            //enemyAnimatorManager.animator.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
            return pursueTargetState;
        }  /* else
        { */

        enemyAnimatorManager.animator.SetFloat("Vertical", 0.5f, 0.1f, Time.deltaTime);
        enemyManager.transform.rotation = Quaternion.LookRotation(targetDirection);
        enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);      
        Vector3 h = Vector3.Normalize(enemyManager.transform.right) * (direction ? 1 : -1) * 600f * Time.deltaTime;
        Vector3 v = Vector3.Normalize(targetDirection) * 400f * (distanceFromTarget > 5 ? 1 : -1) * Time.deltaTime;
        if (Mathf.Round(distanceFromTarget) != 5f)
        {
            enemyManager.enemyRigidBody.AddForce(v + h);
        }
        else
        {
            enemyManager.enemyRigidBody.AddForce(h);
        }
        //} 

        if (enemyManager.transform.position.x < -10)
        {
            enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + new Vector3(1,0,0));
            direction = !direction;
            framecount = 1;
        }
        if (enemyManager.transform.position.x > 10)
        {
            enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + new Vector3(-1, 0, 0));
            direction = !direction;
            framecount = 1;
        }
        if (enemyManager.transform.position.z < -10)
        {
            enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + new Vector3(0, 0, 1));
            direction = !direction;
            framecount = 1;
        }
        if (enemyManager.transform.position.z > 10)
        {
            enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + new Vector3(0, 0, -1));
            direction = !direction;
            framecount = 1;
        }

        return this;
    }
}
