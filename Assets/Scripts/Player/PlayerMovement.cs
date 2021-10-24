using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;
    AnimatorManager animatorManager;

    public CharacterController controller;

    public float movementSpeed;
    public float rollSpeed;
    public float rotationSpeed = 15f;

    public bool isRolling;
    public bool isAttacking;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<AnimatorManager>();

        movementSpeed = playerManager.stats.Speed * 1.2f;
        rollSpeed = playerManager.stats.Speed * 1.5f;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
        HandleRoll();
        HandleAttack();
    }

    private void HandleMovement()
    {
        if (playerManager.isInteracting)
        {
            Vector3 direction = transform.forward;
            if (playerManager.isRolling)
            {
                controller.Move(direction * rollSpeed * Time.deltaTime);
            }
        }
        else
        {
            Vector3 direction = new Vector3(inputManager.horizontalInput, 0f, inputManager.verticalInput).normalized;

            if (direction.magnitude >= 0.1f)
            {
                controller.Move(direction * movementSpeed * Time.deltaTime);
            }
        }
    }

    private void HandleRotation()
    {
        if (inputManager.rollFlag)
            return;

        if (playerManager.isInteracting)
            return;

        Vector3 targetDirection = new Vector3(inputManager.horizontalInput, 0f, inputManager.verticalInput).normalized;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleRoll()
    {
        if (animatorManager.animator.GetBool("isInteracting"))
            return;

        if (inputManager.rollFlag)
        {
            Vector3 direction = new Vector3(inputManager.horizontalInput, 0f, inputManager.verticalInput).normalized;

            if (direction == Vector3.zero)
                direction = transform.forward;

            animatorManager.PlayTargetAnimation("Roll", true);

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void HandleAttack()
    {
        if (animatorManager.animator.GetBool("isInteracting"))
            return;

        if (inputManager.attackFlag)
        {
            Vector3 direction = transform.forward;
            animatorManager.PlayTargetAnimation("Attack", true);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
