using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Titletext;
    public Button StartButton;
    public Button restartButton;
    public Image Blur;
    public bool isGameActive;
    public TextMeshProUGUI gamerOverText;
    public PlayerController playercontroller;
    public PistolController pistolController;
    public GameObject Body;
    public TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        Titletext.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(true);
        Body.GetComponent<LookAtMouse>().enabled = false;
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        Titletext.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        playercontroller.speed = 5.0f;
        Body.GetComponent<LookAtMouse>().enabled = true;
    }
    
    public void GameOver()
    {
        isGameActive = false;
        gamerOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Body.GetComponent<LookAtMouse>().enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
