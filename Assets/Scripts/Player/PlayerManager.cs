using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Vector3 defPos;
    private Quaternion defRot;
    private Vector3 defScale;

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
    public bool isInvulnerable;

    public Reward rewardGame;

    public int startGameBuffer = 0;
    public bool isIntro;
    public bool isOutro;

    [SerializeField] private GameObject attackVFX;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();

        defPos = transform.position;
        defRot = transform.localRotation;
        defScale = transform.localScale;
        isIntro = true;
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
        isInvulnerable = animator.GetBool("isInvulnerable");

        if (isIntro || isOutro)
        {
            animator.SetFloat("Vertical", 0, 0.01f, Time.deltaTime); // stand still
        }
        else
        {
            inputManager.HandleAllInputs();
            playerMovement.HandleAllMovement();
        }
    }

    private void LateUpdate()
    {
        inputManager.rollFlag = false;
    }

    public void ResetTransform()
    {
        transform.position = defPos;
        transform.localRotation = defRot;
        transform.localScale = defScale;
        isIntro = true;
        isOutro = false;
    }

    public void LaunchAttackVFX()
    {
        GameObject clone = Instantiate(attackVFX, transform.position, transform.localRotation);
        Destroy(clone, 1.0f);
    }
}
