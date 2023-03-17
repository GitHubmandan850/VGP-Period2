using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    public GameObject player;
    public float health = 20f;

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
    }
    private void OnCollisionEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            health -= 5;
        }
    }
}
