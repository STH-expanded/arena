using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animatorManager;
    PlayerManager playerManager;
    PlayerMovement playerMovement;
    WeaponSlotManager weaponSlotManager;

    public Vector2 movementInput;
    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool a_Input;
    public bool b_Input;
    public bool rollFlag;
    public bool attackFlag;
    public bool comboFlag;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerManager = GetComponent<PlayerManager>();
        playerMovement = GetComponent<PlayerMovement>();
        weaponSlotManager = GetComponent<WeaponSlotManager>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleRollInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleRollInput()
    {
        b_Input = playerControls.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;

        if (b_Input)
        {
            rollFlag = true;
        }
    }

    private void HandleAttackInput()
    {
        a_Input = playerControls.PlayerActions.Attack.phase == UnityEngine.InputSystem.InputActionPhase.Started;

        if (a_Input)
        {
            if (playerManager.canCombo)
            {
                comboFlag = true;
            }
            else
            {
                if (playerManager.isInteracting)
                    return;

                if (playerManager.canCombo)
                    return;

                attackFlag = true;
            }
        }
    }
}
