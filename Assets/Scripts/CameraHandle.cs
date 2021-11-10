using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    void Update()
    {
        Vector3 center = (player.transform.position + enemy.transform.position) / 2;
        float dist = Vector3.Distance(player.transform.position, enemy.transform.position) + 2;
        if (dist < 8) dist = 8;
        transform.position = Vector3.Lerp(transform.position, center + transform.forward * -dist, 0.1f);
    }

    public void Shake()
    {
        transform.position += Random.insideUnitSphere * 0.5f;
    }
}
