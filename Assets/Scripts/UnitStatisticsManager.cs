using UnityEngine;
using Random = UnityEngine.Random;

public class UnitStatisticsManager : MonoBehaviour
{
    public UnitStatistics unitStatistics;
    Animator animator;
    public CameraHandle cameraHandle;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void InitLevel(int baseLevel)
    {
        unitStatistics = new UnitStatistics();
        while (unitStatistics.Level < baseLevel) LevelUp();
        unitStatistics.CurrentHealth = unitStatistics.Health;
    }

    public void InitStats(UnitStatistics stats)
    {
        unitStatistics = stats;
        unitStatistics.CurrentHealth = unitStatistics.Health;
        Debug.Log(unitStatistics);
    }

    public void LevelUp()
    {
        if (unitStatistics.HealthGrowth > Random.Range(0.0f, 1.0f)) unitStatistics.Health++;
        if (unitStatistics.AttackGrowth > Random.Range(0.0f, 1.0f)) unitStatistics.Attack++;
        if (unitStatistics.DefenseGrowth > Random.Range(0.0f, 1.0f)) unitStatistics.Defense++;
        if (unitStatistics.SpeedGrowth > Random.Range(0.0f, 1.0f)) unitStatistics.Speed++;
        unitStatistics.Level++;
    }

    public void TakeDamage(int damage)
    {
        if (gameObject.name == "Player")
        {
            if (gameObject.GetComponent<PlayerManager>().isInvulnerable)
                return;
        }
        else if (gameObject.name == "Enemy")
        {

        }

        unitStatistics.CurrentHealth -= damage;
        cameraHandle.Shake();

        if (unitStatistics.CurrentHealth <= 0) {
            unitStatistics.CurrentHealth = 0;
            animator.Play("Death");
        }
        else
        {
            animator.Play("Hit");
        }
    }
}