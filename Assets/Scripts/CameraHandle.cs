using UnityEngine;
using Random = UnityEngine.Random;

public class CameraHandle : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public bool isEnemyDead;
    public bool isPlayerDead;
    public bool isIntro;

    Transform _currentView;

    private void Awake()
    {
        _currentView = transform;
    }

    void Update()
    {
        if (isIntro)
        {
            EntryCinematic();
        }
        else
        {
            if (isEnemyDead)
            {
                ZoomOnEnemy();
            }
            else if (isPlayerDead) {
            
            }
            else
            {
                var center = (player.transform.position + enemy.transform.position) / 2;
                var dist = Vector3.Distance(player.transform.position, enemy.transform.position) + 2;
                if (dist < 8) dist = 8;
                transform.position = Vector3.Lerp(_currentView.position, center + transform.forward * -dist, Time.deltaTime * 5);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(55, 0, 0), Time.deltaTime * 5);
            }
        }
    }

    public void Shake()
    {
        transform.position += Random.insideUnitSphere * 0.5f;
    }

    private void EntryCinematic()
    {
        var center = (enemy.transform.position);
        transform.position = Vector3.Lerp(transform.position, center + transform.forward * -7, 0.05f);
        transform.rotation = Quaternion.Euler(20, 0, 0);
        _currentView = transform;
    }

    private void ZoomOnEnemy()
    {
        var center = (enemy.transform.position);
        transform.position = Vector3.Lerp(transform.position, center + transform.forward * -4, 0.01f);
    }
}
