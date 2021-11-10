using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement playerMovement;
    Animator animator;
    public UnitStatisticsManager unitStatisticsManager;

   [Header("Player flags")]
    public bool isInteracting;
    public bool isAttacking;
    public bool isRolling;
    public bool isHit;
    public bool canCombo;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();
        unitStatisticsManager.InitLevelUp(1);
}

    private void Update()
    {
        isInteracting = animator.GetBool("isInteracting");
        isAttacking = animator.GetBool("isAttacking");
        isRolling = animator.GetBool("isRolling");
        isHit = animator.GetBool("isHit");
        canCombo = animator.GetBool("canCombo");

        inputManager.HandleAllInputs();
        playerMovement.HandleAllMovement();
    }

    private void LateUpdate()
    {
        inputManager.rollFlag = false;
        inputManager.attackFlag = false;
    }
}
