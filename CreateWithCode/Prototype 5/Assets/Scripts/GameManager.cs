using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gamerOverText;
    private int score;
    public Button restartButton;
    public bool isGameActive;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        spawnRate /= difficulty;
        isGameActive = false;
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    
    public void GameOver()
    {
        isGameActive = false;
        gamerOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

