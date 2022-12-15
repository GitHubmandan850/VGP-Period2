using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obsticlePrefabs;
    private Vector3 spawnPos = new Vector3(35,  0, 3.6f);

    private float startDely = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObsticle", startDely, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObsticle()
    {
        int obsticleIndex = Random.Range(0, obsticlePrefabs.Length); 

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obsticlePrefabs[obsticleIndex], spawnPos, obsticlePrefabs[obsticleIndex].transform.rotation);
        }
        
    }

}
