using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement playerMovement;
    Animator animator;

    [Header("Player flags")]
    public bool isInteracting;
    public bool isRolling;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isInteracting = animator.GetBool("isInteracting");

        inputManager.HandleAllInputs();
        playerMovement.HandleAllMovement();
    }

    private void LateUpdate()
    {
        inputManager.rollFlag = false;
    }
}
