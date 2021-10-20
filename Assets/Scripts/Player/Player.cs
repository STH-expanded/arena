using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public PlayerStatistics statistics; 
    public HealthBar HealthBar; 
    // Start is called before the first frame update
    void Start()
    {
        statistics = GetComponent<PlayerStatistics>();
        statistics.CurrentHealth = statistics.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.SetCurrentHealth(statistics.CurrentHealth);
        
        if (statistics.CurrentHealth <= 0)
        {
            Debug.Log("game over !");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
