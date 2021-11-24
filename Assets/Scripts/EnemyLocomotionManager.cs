using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;

    public LayerMask detectionLayer;

    private void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
    }
}
