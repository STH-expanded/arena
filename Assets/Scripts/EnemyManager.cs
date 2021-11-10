using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyLocomotionManager enemyLocomotionManager;
    public bool isPreformingAction;
    public UnitStatisticsManager unitStatisticsManager;

    [Header("A,I Settings")]
    public float detectionRadius = 20;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;

    // Start is called before the first frame update
    private void Awake()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();
        unitStatisticsManager.InitStats(DataSaver.loadData<UnitStatistics>("enemy"));
        Debug.Log(unitStatisticsManager.unitStatistics.Health);
    }

    // Update is called once per frame
    private void Update()
    {
        if (unitStatisticsManager.unitStatistics.CurrentHealth <= 0)
            return;
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

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager playerManager = other.GetComponent<PlayerManager>();

        if (playerManager != null)
        {
            playerManager.unitStatisticsManager.TakeDamage(4);
        }
    }
}
