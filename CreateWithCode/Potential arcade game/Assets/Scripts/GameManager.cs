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
    public int ammo = 10;
    public TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        Titletext.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(true);
        Body.GetComponent<LookAtMouse>().enabled = false;
        UpdateAmmo(ammo);
    }

    void Update()
    {
        float ammoClamp = Mathf.Clamp(ammo, 0f, 10f);
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

    public void UpdateAmmo(int AmmoToAdd)
    {
        ammoText.text = "Ammo: " + ammo;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
