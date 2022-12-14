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

    [SerializeField]
    Text scoreText;

    public int TotalScore;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObsticle", startDely, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore = obsticlePrefabs.GetInt("Score", 0);
        scoreText.Text = "Score" + TotalScore.ToString();
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
