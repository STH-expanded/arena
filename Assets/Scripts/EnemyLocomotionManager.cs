using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;
    NavMeshAgent navMeshAgent;
    public Rigidbody enemyRigidBody;

    public PlayerManager currentTarget;
    public LayerMask detectionLayer;

    public float distanceFromTarget;
    public float stoppingDistance = 1f;

    public float rotationSpeed = 15; 

    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        navMeshAgent.enabled = false;
        enemyRigidBody.isKinematic = false;
    }

    public void HandleDetection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);
    
        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerManager characterStats = colliders[i].transform.GetComponent<PlayerManager>();

             if (characterStats != null)
             {
                 //CHECK FOR TEAM ID
             }
             

            Vector3 targetDirection = characterStats.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
            {
                currentTarget = characterStats;
            }
        }   
    }

    public void HandleMoveToTarget()
    {
        Vector3 targetDirection = currentTarget.transform.position;
        distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);


        if (enemyManager.isPreformingAction)
        {
            enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            navMeshAgent.enabled = false;
        }
        else
        {
            if (distanceFromTarget > stoppingDistance)
            {
                enemyAnimatorManager.animator.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
            } 
            else if (distanceFromTarget <= stoppingDistance)
            {
                enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            }
        }

        HandleRotateTowardsTarget();
        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.transform.localRotation = Quaternion.identity;

    }

    private void HandleRotateTowardsTarget()
    {
        if (enemyManager.isPreformingAction)
        {
            Vector3 direction = currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyRigidBody.velocity;

            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(currentTarget.transform.position);
            enemyRigidBody.velocity = targetVelocity;
            transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);
        }
    }
}
