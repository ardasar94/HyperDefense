using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject LooseScreen;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject PauseScreen;

    [SerializeField] TextMeshProUGUI screwText;

    PlayerInfo playerInfo;
    WavesController wavesController;

    [SerializeField] GameObject DoubleCannonButton;
    [SerializeField] GameObject GatlingButton;
    [SerializeField] GameObject FlamerButton;

    // Start is called before the first frame update
    void Start()
    {
        wavesController = FindObjectOfType<WavesController>();
        playerInfo = FindObjectOfType<PlayerInfo>();
        CalculateEarnedScrew();
        CheckActivenesses();
    }



    // Update is called once per frame
    void Update()
    {
        HealthControl();
        ShowWinScreen();
    }
    private void CheckActivenesses()
    {
        if (PlayerPrefController.GetDoubleCannonActiveness() == 0)
        {
            DoubleCannonButton.SetActive(false);
        }
        if (PlayerPrefController.GetGatlingActiveness() == 0)
        {
            GatlingButton.SetActive(false);
        }
        if (PlayerPrefController.GetFlamerActiveness() == 0)
        {
            FlamerButton.SetActive(false);
        }
    }
    private void CalculateEarnedScrew()
    {
        int EarnedScrew = SceneManager.GetActiveScene().buildIndex * 50;
        var screwBank = FindObjectOfType<ScrewBank>();
        screwBank.IncreaseScrews(EarnedScrew);
        screwText.text = "Earned: " + EarnedScrew + " Screws";
    }

    private void HealthControl()
    {
        if (PauseScreen.activeInHierarchy || WinScreen.activeInHierarchy || LooseScreen.activeInHierarchy) {return;}
        if (playerInfo.IsALive())
        {
            Time.timeScale = 0;
            LooseScreen.SetActive(true);
        }
    }

    public void ShowWinScreen()
    {
        if (PauseScreen.activeInHierarchy || WinScreen.activeInHierarchy || LooseScreen.activeInHierarchy) { return; }
        if (wavesController.IsSpawnEnd() && !FindObjectOfType<Enemy>())
        {
            Time.timeScale = 0;
            WinScreen.SetActive(true);
        }
    }

    public void PauseGameScreen() 
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);

    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void ResumeGameScreen()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }
}
