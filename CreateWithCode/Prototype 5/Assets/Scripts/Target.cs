using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int value;
    private GameManager gameManager;
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float XRange = 4;
    private float YSpawnPos = -6;
    public ParticleSystem ExplotionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(value);
            Instantiate(ExplotionParticle, transform.position, ExplotionParticle.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
        }
    }

   Vector3 RandomForce()
   {
       return Vector3.up * Random.Range(minSpeed, maxSpeed);
   }
   float RandomTorque()
   {
       return Random.Range(-maxTorque, maxTorque);
   }
   Vector3 RandomSpawnPos()
   {
       return new Vector3(Random.Range(-XRange, XRange), YSpawnPos);
   }
   public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(ExplotionParticle, transform.position,
            ExplotionParticle.transform.rotation);
            gameManager.UpdateScore(value);
        }
    }
}
