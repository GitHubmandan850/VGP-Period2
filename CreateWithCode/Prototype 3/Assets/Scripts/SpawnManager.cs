using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsticlePrefab;
    private Vector3 spawnPos = new Vector3(25,  6.19f, -6.8f);

    private float startDely = 2;
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObsticle", startDely, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObsticle()
    {
        Instantiate(obsticlePrefab, spawnPos, obsticlePrefab.transform.rotation);
    }
}