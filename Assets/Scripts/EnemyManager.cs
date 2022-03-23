using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    EnemyLocomotionManager enemyLocomotionManager;
    EnemyAnimatorManager enemyAnimationManager;
    public NavMeshAgent navMeshAgent;

    public State currentState;
    public PlayerManager currentTarget;
    public bool isPreformingAction;
    public UnitStatisticsManager unitStatisticsManager;
    public float rotationSpeed;
    public float maximumAggroRadius = 0.5f;
    public Rigidbody enemyRigidBody;
    public EnemyManager enemyManager;

    private Vector3 defPos;
    private Quaternion defRot;
    private Vector3 defScale;

    [Header("A,I Settings")]
    public float detectionRadius = 20;
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;
    public float viewableAngle;

    public float currentRecoveryTime = 0;
    public int startGameBuffer = 0;
    public bool isIntro;
    public bool isOutro;

    [SerializeField] private GameObject attackVFX;
    [SerializeField] private GameObject attackVFXReverse;
    [SerializeField] private GameObject cloudVFX;
    [SerializeField] private GameObject hitVFX;

    // Start is called before the first frame update
    private void Awake()
    {
        enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
        enemyAnimationManager = GetComponentInChildren<EnemyAnimatorManager>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();
        navMeshAgent.enabled = false;
        enemyRigidBody = GetComponent<Rigidbody>();

        defPos = transform.position;
        defRot = transform.localRotation;
        defScale = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        if (unitStatisticsManager.unitStatistics.CurrentHealth == 0)
            return;

        if (isIntro)
        {
            //enemyAnimationManager.animator.SetFloat("Vertical", 1, 0.01f, Time.deltaTime); // move forward
            enemyManager.enemyRigidBody.MovePosition(enemyManager.transform.position + Vector3.forward * -10f * Time.deltaTime);
        }
        else if (isOutro)
        {
            enemyAnimationManager.animator.SetFloat("Vertical", 0, 0.01f, Time.deltaTime); // stand still

        }
        else
        {
            HandleRecoveryTimer();
            HandleStateMachine();
        }
    }

    private void HandleStateMachine()
    {
        if (currentState != null)
        {
            State nextState = currentState.Tick(this, unitStatisticsManager.unitStatistics, enemyAnimationManager);

            if (nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }
    }

    private void SwitchToNextState(State state)
    {
        currentState = state;
    }

    private void HandleRecoveryTimer()
    {
        if (currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if (isPreformingAction)
        {
            if (currentRecoveryTime <= 0)
            {
                isPreformingAction = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager playerManager = other.GetComponent<PlayerManager>();

        if (playerManager != null && unitStatisticsManager.unitStatistics.CurrentHealth > 0)
        {
            var hitPlayerSound = GameObject.Find("HitPlayer");
            hitPlayerSound.GetComponent<AudioSource>().Play();
            playerManager.unitStatisticsManager.TakeDamage(4);
        }
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

    public void LaunchAttackVFX2()
    {
        GameObject clone = Instantiate(attackVFXReverse, transform.position, transform.localRotation);
        Destroy(clone, 1.0f);
    }
    public void LaunchWalkVFX()
    {
        GameObject clone = Instantiate(cloudVFX, transform.position, transform.localRotation);
        Destroy(clone, 1.0f);
    }
    public void LaunchHitVFX()
    {
        GameObject clone = Instantiate(hitVFX, transform.position, transform.localRotation);
        Destroy(clone, 1.0f);
    }
}
