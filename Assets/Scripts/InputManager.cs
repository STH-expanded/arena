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
    public bool a_Buffer;
    public bool b_Input;
    public bool rollFlag;
    public bool attack1Flag;
    public bool attack2Buffer;
    public bool attack3Buffer;
    public bool stabBuffer;

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
        Debug.Log(playerControls.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started);
        b_Input = playerControls.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;

        if (b_Input)
        {
            rollFlag = true;
        }
    }

    private void HandleAttackInput()
    {
        a_Input = playerControls.PlayerActions.Attack.phase == UnityEngine.InputSystem.InputActionPhase.Started;

        if (playerManager.canAttack3 && a_Input && !a_Buffer)
        {
            attack3Buffer = true;
        }
        else if (playerManager.canAttack2 && a_Input && !a_Buffer)
        {
            attack2Buffer = true;
        }
        else
        {
            attack1Flag = a_Input && !a_Buffer;
        }

        if (playerManager.isRolling && a_Input && !a_Buffer)
        {
            stabBuffer = true;
        }

        a_Buffer = a_Input;
    }
}
