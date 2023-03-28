using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 20f;
    public GameManager gameManager;
    public ParticleSystem hit;
    public Transform Playerpos;
    private rigidbody rb;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        agent.destination = Playerpos.position;
        hit.transform.position = transform.position;
        Vector3 lookDirection = (Playerpos.transform.position - transform.position).normalized;

        if(health < 0f)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= 5;
            hit.Play();
        }
    }
}
