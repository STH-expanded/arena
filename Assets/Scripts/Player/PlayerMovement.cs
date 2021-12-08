using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;
    AnimatorManager animatorManager;
    WeaponSlotManager weaponSlotManager;

    public CharacterController controller;

    public float movementSpeed;
    public float rollSpeed;
    public float rotationSpeed;
    public string lastAttack;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<AnimatorManager>();
        weaponSlotManager = GetComponent<WeaponSlotManager>();
    }

    private void Start()
    {
        movementSpeed = playerManager.unitStatisticsManager.unitStatistics.Speed;
        rollSpeed = playerManager.unitStatisticsManager.unitStatistics.Speed * 1.2f;
    }

    public void HandleAllMovement()
    {
        if (playerManager.isHit || playerManager.unitStatisticsManager.unitStatistics.CurrentHealth == 0)
            return;

        HandleMovement();

        if (playerManager.isInteracting)
            return;

        HandleRotation();
        HandleAttack();
        HandleRoll();
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
            if (playerManager.isStabbing)
            {
                controller.Move(direction * rollSpeed * 0.25f * Time.deltaTime);
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

        Vector3 targetDirection = new Vector3(inputManager.horizontalInput, 0f, inputManager.verticalInput).normalized;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void HandleRoll()
    {
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
        if (inputManager.stabBuffer)
        {
            inputManager.stabBuffer = false;
            animatorManager.PlayTargetAnimation("Stab", true);
        }
        else if (inputManager.attack3Buffer)
        {
            inputManager.attack3Buffer = false;
            animatorManager.PlayTargetAnimation(weaponSlotManager.weaponItem.Attack3, true);
        }
        else if (inputManager.attack2Buffer)
        {
            inputManager.attack2Buffer = false;
            animatorManager.PlayTargetAnimation(weaponSlotManager.weaponItem.Attack2, true);
        }
        if (inputManager.attack1Flag)
        {
            Vector3 direction = transform.forward;
            transform.rotation = Quaternion.LookRotation(direction);
            animatorManager.PlayTargetAnimation(weaponSlotManager.weaponItem.Attack1, true);
        }
    }
}
