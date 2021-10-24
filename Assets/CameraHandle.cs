using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    void Update()
    {
        Vector3 p = transform.position;
        p.x = player.transform.position.x + (enemy.transform.position.x - player.transform.position.x) / 2;
        p.z = player.transform.position.z + (enemy.transform.position.z - player.transform.position.z) / 2 - 5;
        transform.position = p;
    }
}
