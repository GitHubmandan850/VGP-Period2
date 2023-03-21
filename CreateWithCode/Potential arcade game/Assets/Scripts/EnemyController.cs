using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 20f;
    public float speed;
    private Rigidbody enemyRb;
    public GameObject player;
    public GameManager gameManager;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        if(health < 0f)
        {
            Destroy(gameObject);
        }
        if(gameManager.isGameActive = false)
        {
            speed = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= 5;
        }
    }
}
