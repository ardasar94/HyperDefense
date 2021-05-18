using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurretUIController : MonoBehaviour
{
    [SerializeField] GameObject DoubleCannon;
    [SerializeField] GameObject Gatling;
    [SerializeField] GameObject Flamer;

    [SerializeField] TextMeshProUGUI displayCannonApText;
    [SerializeField] TextMeshProUGUI displayCannonUpgradeText;

    [SerializeField] TextMeshProUGUI displayDoubleCannonApText;
    [SerializeField] TextMeshProUGUI displayDoubleCannonUpgradeText;

    [SerializeField] TextMeshProUGUI displayGatlingApText;
    [SerializeField] TextMeshProUGUI displayGatlingUpgradeText;

    [SerializeField] TextMeshProUGUI displayFlamerApText;
    [SerializeField] TextMeshProUGUI displayFlamerUpgradeText;
    // Start is called before the first frame update
    void Start()
    {
        ShowOrHideActiveness();
        SetCannonPriceAndAp();
        SetDoubleCannonPriceAndAp();
        SetGatlingPriceAndAp();
        SetFlamerPriceAndAp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOrHideActiveness()
    {
        if (PlayerPrefController.GetDoubleCannonActiveness() == 0)
        {
            DoubleCannon.SetActive(true);
        }
        else
        {
            DoubleCannon.SetActive(false);
        }
        if (PlayerPrefController.GetGatlingActiveness() == 0)
        {
            Gatling.SetActive(true);
        }
        else
        {
            Gatling.SetActive(false);
        }
        if (PlayerPrefController.GetFlamerActiveness() == 0)
        {
            Flamer.SetActive(true);
        }
        else
        {
            Flamer.SetActive(false);
        }
    }

    public void SetCannonPriceAndAp()
    {
        displayCannonApText.text = "AP: " + PlayerPrefController.GetCannonAP();
        displayCannonUpgradeText.text = "UPGRADE " + PlayerPrefController.GetCannonUpgradeAmount() + " SCREWS";
    }

    public void SetDoubleCannonPriceAndAp()
    {
        displayDoubleCannonApText.text = "AP: " + PlayerPrefController.GetDoubleCannonAP();
        displayDoubleCannonUpgradeText.text = "UPGRADE " + PlayerPrefController.GetDoubleCannonUpgradeAmount() + " SCREWS";
    }

    public void SetGatlingPriceAndAp()
    {
        displayGatlingApText.text = "AP: " + PlayerPrefController.GetGatlingAP();
        displayGatlingUpgradeText.text = "UPGRADE " + PlayerPrefController.GetGatlingUpgradeAmount() + " SCREWS";
    }

    public void SetFlamerPriceAndAp()
    {
        displayFlamerApText.text = "AP: " + PlayerPrefController.GetFlamerAP();
        displayFlamerUpgradeText.text = "UPGRADE " + PlayerPrefController.GetFlamerUpgradeAmount() + " SCREWS";
    }
}
