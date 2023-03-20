using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    public GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}