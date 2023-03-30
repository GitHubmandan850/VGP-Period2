using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 20f;
    public GameManager gameManager;
    public ParticleSystem hit;
    public Transform Playerpos;
    private Rigidbody rb;
    public GameObject damaged;
    public GameObject Normal;
    public bool isAlive = false;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isAlive = true)
        {
            agent.destination = Playerpos.position;
            hit.transform.position = transform.position;
            Vector3 lookDirection = (Playerpos.transform.position - transform.position).normalized;
        }
        
        if(health < 0f)
        {
            Destroy(gameObject);
        }

        if(health < 10f)
        {
            damaged.gameObject.SetActive(true);
            Normal.gameObject.SetActive(false);
        }
        
        health = Mathf.Clamp(health, 0, 20);
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
