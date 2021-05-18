using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrewBank : MonoBehaviour
{
    [SerializeField] int startScrews = 1000;
    [SerializeField] TextMeshProUGUI displaySrewBalanceMainMenu;
    [SerializeField] TextMeshProUGUI displaySrewBalanceUpgradeMenu;
    AudioSource screwLooseSound;

    int currentScrew;
    // Start is called before the first frame update

    private void Awake()
    {
        int numScrewBank = FindObjectsOfType<ScrewBank>().Length;
        if (numScrewBank > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        screwLooseSound = GetComponent<AudioSource>();
        currentScrew = PlayerPrefController.GetScrewBankAmount();
        DisplayScrewText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScrews(int amount)
    {
        PlayerPrefController.SetScrewToBank(PlayerPrefController.GetScrewBankAmount() + amount);
        currentScrew = PlayerPrefController.GetScrewBankAmount();
        DisplayScrewText();
    }

    public void DecreaseScrews(int amount)
    {
        PlayerPrefController.SetScrewToBank(PlayerPrefController.GetScrewBankAmount() - amount);
        currentScrew = PlayerPrefController.GetScrewBankAmount();
        DisplayScrewText();
        screwLooseSound.Play();
    }

    public void DisplayScrewText()
    {
        currentScrew = PlayerPrefController.GetScrewBankAmount();
        displaySrewBalanceMainMenu.text = "Screw: " + currentScrew;
        displaySrewBalanceUpgradeMenu.text = "Screw: " + currentScrew;
    }

    public int GetstartScrews()
    {
        return startScrews;
    }
}
