using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsticlePrefab;
    private Vector3 spawnPos = new Vector3(25,  6.19f, -6.8f);

    private float startDely = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObsticle", startDely, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObsticle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obsticlePrefab, spawnPos, obsticlePrefab.transform.rotation);
        }
        
    }

}
