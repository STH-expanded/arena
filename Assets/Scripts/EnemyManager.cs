using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyLocomotionManager enemyLocomotionManager;
    public bool isPreformingAction;


    [Header("A,I Settings")]
    public float detectionRadius = 20;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;

    // Start is called before the first frame update
    private void Awake()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleCurrentAction();
    }

    private void FixedUpdate()
    {
        HandleCurrentAction();
    }

    private void HandleCurrentAction()
    {
        if (enemyLocomotionManager.currentTarget == null)
        {
            enemyLocomotionManager.HandleDetection();
        }
        else
        {
            enemyLocomotionManager.HandleMoveToTarget();
        }
    }
}
