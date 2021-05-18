using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DisplayUIs : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] GameObject healthSlider;
    [SerializeField] TextMeshProUGUI healthText;

    [Header("Waves")]
    [SerializeField] GameObject waves;
    [SerializeField] GameObject waveSlider;
    [SerializeField] TextMeshProUGUI wavesText;
    [SerializeField] TextMeshProUGUI wavePercentText;

    PlayerInfo playerInfo;
    int maxHealth;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();     
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealthTextAndSlider();
        DisplayWavesTextAndSlider();
    }

    private void DisplayWavesTextAndSlider()
    {
        int totalwaves = waves.transform.childCount;
        int currentWaves = 0;
        for (int i = 0; i < totalwaves; i++)
        {
            var currentWaveGameObject = waves.transform.GetChild(i).gameObject;
            if (!currentWaveGameObject.activeInHierarchy) continue;
            else
            {
                currentWaves = i + 1;
            }           
        }

        float maxVehicle = 1;
        float currentVehicle = 0;
        if (currentWaves > 0)
        {
            var wave = waves.transform.GetChild(currentWaves - 1);
            maxVehicle = wave.GetComponent<Wave>().WaveEnemiesSize();
            currentVehicle = wave.transform.childCount;
        }       
        wavesText.text = $"WAVE: {currentWaves}/{totalwaves}";
        wavePercentText.text = ((int)(currentVehicle / maxVehicle * 100)).ToString() + "%";
        waveSlider.GetComponent<Slider>().value = currentVehicle / maxVehicle;

    }

    private void DisplayHealthTextAndSlider()
    {
        maxHealth = playerInfo.GetMaxHealth();
        currentHealth = playerInfo.GetCurrentHealth();
        healthText.text = currentHealth + "/" + maxHealth;
        float floatCurrentHealth = (float)currentHealth;
        float floatMaxHealth = (float)maxHealth;
        float percentHealth = floatCurrentHealth / floatMaxHealth;
        healthSlider.GetComponent<Slider>().value = percentHealth;
    }
}
