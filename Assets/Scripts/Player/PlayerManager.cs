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
    public bool isRolling;
    public bool isStabbing;
    public bool isHit;
    public bool isAttack1;
    public bool isAttack2;
    public bool isAttack3;
    public bool canAttack2;
    public bool canAttack3;

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
        isRolling = animator.GetBool("isRolling");
        isStabbing = animator.GetBool("isStabbing");
        isHit = animator.GetBool("isHit");
        isAttack1 = animator.GetBool("isAttack1");
        isAttack2 = animator.GetBool("isAttack2");
        isAttack3 = animator.GetBool("isAttack3");
        canAttack2 = animator.GetBool("canAttack2");
        canAttack3 = animator.GetBool("canAttack3");

        inputManager.HandleAllInputs();
        playerMovement.HandleAllMovement();
    }

    private void LateUpdate()
    {
        inputManager.rollFlag = false;
    }
}
