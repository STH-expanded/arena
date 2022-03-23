using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraHandle : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public bool isEnemyDead;
    public bool isPlayerDead;
    public bool isIntro;

    Vector3 _initialCameraPosition;
    Transform _currentView;

    private void Start()
    {
        _initialCameraPosition = transform.position;
    }
    

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
                // ZoomOnEnemy();
                FocusCameraOnMenuCards();
                // StartCoroutine(FocusCameraOnMenuCards());
            }
            else if (isPlayerDead)
            {
                
            }
            else
            {
                Debug.Log("I'm here!");
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
        Debug.Log("I'm in entry cinematic!");
        var center = (enemy.transform.position);
        transform.position = Vector3.Lerp(transform.position, center + transform.forward * -7, 0.05f);
        transform.rotation = Quaternion.Euler(20, 0, 0);
        _currentView = transform;
    }

    private void ZoomOnEnemy()
    {
        var center = (enemy.transform.position);
        transform.position = Vector3.Lerp(transform.position, center + transform.forward * -4, 0.01f);
        Debug.Log("Zoom on enemy func!");
    }

    private void FocusCameraOnMenuCards()
    {
        transform.position = new Vector3(0, 14.74474F, -10.32438F); //_initialCameraPosition; //Vector3.Lerp(transform.position, _initialCameraPosition, 0.05f);
    }
    IEnumerator FocusCameraOnMenuCards1()
    {
        Debug.Log("Focus camera func!");
        yield return new WaitForSeconds(0.2F);
        transform.position = _initialCameraPosition; //Vector3.Lerp(transform.position, _initialCameraPosition, 0.05f);
    }
}
