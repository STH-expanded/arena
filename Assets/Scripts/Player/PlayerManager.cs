using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement playerMovement;
    Animator animator;

    public UnitStatistics stats = new UnitStatistics(1);

    [Header("Player flags")]
    public bool isInteracting;
    public bool isAttacking;
    public bool isRolling;
    public bool isHit;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isInteracting = animator.GetBool("isInteracting");
        isAttacking = animator.GetBool("isAttacking");
        isRolling = animator.GetBool("isRolling");
        isHit = animator.GetBool("isHit");

        inputManager.HandleAllInputs();
        playerMovement.HandleAllMovement();
    }

    private void LateUpdate()
    {
        inputManager.rollFlag = false;
        inputManager.attackFlag = false;
    }

    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);

        if (stats.CurrentHealth <= 0)
        {
            stats.CurrentHealth = 0;
            animator.Play("Death");
        }
        else
        {
            animator.Play("Hit");
        }
    }
}
