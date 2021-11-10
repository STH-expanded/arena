using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitStatisticsManager : MonoBehaviour
{
    public UnitStatistics unitStatistics;
    Animator animator;
    public CameraHandle cameraHandle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void InitLevelUp(int baseLevel)
    {
        unitStatistics = new UnitStatistics();
        while (unitStatistics.Level < baseLevel) LevelUp();
        unitStatistics.CurrentHealth = unitStatistics.Health;
    }

    public void InitStats(UnitStatistics stats)
    {
        unitStatistics = stats;
        unitStatistics.CurrentHealth = unitStatistics.Health;
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
        unitStatistics.CurrentHealth -= damage;
        cameraHandle.Shake();

        if (unitStatistics.CurrentHealth <= 0) {
            unitStatistics.CurrentHealth = 0;
            animator.Play("Death");
            
            if (CompareTag("Enemy")) {
                GameData gameData;
                string path = Application.persistentDataPath + "/gameData.save";

                if (File.Exists(path)) {
                    gameData = SaveLoad.LoadData();
                    gameData.killCount += 1;
                } else {
                    gameData = new GameData();
                    gameData.unitStatistics = unitStatistics;
                    gameData.killCount += 1;
                }

                SaveLoad.SaveData(gameData);
            }
        }
        else
        {
            animator.Play("Hit");
        }
    }
}
