using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    int cannonDamageLV0 = 40;
    int doubleCannonDamageLV0 = 90;
    int gatlingDamageLV0 = 350;
    int flamerDamageLV0 = 10;

    int cannonDamageCurrent;
    int doubleCannonDamageCurrent;
    int gatlingDamageCurrent;
    int flamerDamageCurrent;

    int doubleCannonActivenessDefault = 0;
    int gatlingActivenessDefault = 0;
    int flamerActivenessDefault = 0;

    int doubleCannonActivenessCurrent;
    int gatlingActivenessCurrent;
    int flamerActivenessCurrent;

    int doubleCannonActivenessScrewAmount = 200;
    int gatlingActivenessScrewAmount = 300;
    int flamerActivenessScrewAmount = 400;

    int cannonUpgradeAmountLV0 = 40;
    int doubleCannonUpgradeAmountLV0 = 90;
    int gatlingUpgradeAmountLV0 = 120;
    int flamerUpgradeAmountLV0 = 200;

    int cannonUpgradeAmountCurrent;
    int doubleCannonUpgradeAmountCurrent;
    int gatlingUpgradeAmountCurrent;
    int flamerUpgradeAmountCurrent;

    [SerializeField] TurretUIController turretUIController;
    [SerializeField] ScrewBank screwBank;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        cannonDamageCurrent = PlayerPrefController.GetCannonAP();
        doubleCannonDamageCurrent = PlayerPrefController.GetDoubleCannonAP();
        gatlingDamageCurrent = PlayerPrefController.GetGatlingAP();
        flamerDamageCurrent = PlayerPrefController.GetFlamerAP();

        doubleCannonActivenessCurrent = PlayerPrefController.GetDoubleCannonActiveness();
        gatlingActivenessCurrent = PlayerPrefController.GetGatlingActiveness();
        flamerActivenessCurrent = PlayerPrefController.GetFlamerActiveness();

        cannonUpgradeAmountCurrent = PlayerPrefController.GetCannonUpgradeAmount();
        doubleCannonUpgradeAmountCurrent = PlayerPrefController.GetDoubleCannonUpgradeAmount();
        gatlingUpgradeAmountCurrent = PlayerPrefController.GetGatlingUpgradeAmount();
        flamerUpgradeAmountCurrent = PlayerPrefController.GetFlamerUpgradeAmount();

        screwBank.DisplayScrewText();
    }

    public void IncreaseCannonAP()
    {
        if (PlayerPrefController.GetScrewBankAmount() >= PlayerPrefController.GetCannonUpgradeAmount())
        {
            screwBank.DecreaseScrews(PlayerPrefController.GetCannonUpgradeAmount());
            PlayerPrefController.SetCannonUpgradeAmount(PlayerPrefController.GetCannonUpgradeAmount() * 3 / 2);
            cannonUpgradeAmountCurrent = PlayerPrefController.GetCannonUpgradeAmount();
            screwBank.DisplayScrewText();

            PlayerPrefController.SetCannonAP(cannonDamageCurrent * 11 / 10);
            cannonDamageCurrent = PlayerPrefController.GetCannonAP();
            turretUIController.SetCannonPriceAndAp();
        }
    }

    public void IncreaseDoubleCannonAP()
    {
        if (PlayerPrefController.GetScrewBankAmount() >= PlayerPrefController.GetDoubleCannonUpgradeAmount())
        {
            screwBank.DecreaseScrews(PlayerPrefController.GetDoubleCannonUpgradeAmount());
            PlayerPrefController.SetDoubleCannonUpgradeAmount(PlayerPrefController.GetDoubleCannonUpgradeAmount() * 3 / 2);
            doubleCannonUpgradeAmountCurrent = PlayerPrefController.GetDoubleCannonUpgradeAmount();
            screwBank.DisplayScrewText();

            PlayerPrefController.SetDoubleCannonAP(doubleCannonDamageCurrent * 11 / 10);
            doubleCannonDamageCurrent = PlayerPrefController.GetDoubleCannonAP();
            turretUIController.SetDoubleCannonPriceAndAp();
        }
    }

    public void IncreaseGatlingAP()
    {
        if (PlayerPrefController.GetScrewBankAmount() >= PlayerPrefController.GetGatlingUpgradeAmount())
        {
            screwBank.DecreaseScrews(PlayerPrefController.GetGatlingUpgradeAmount());
            PlayerPrefController.SetGatlingUpgradeAmount(PlayerPrefController.GetGatlingUpgradeAmount() * 3 / 2);
            gatlingUpgradeAmountCurrent = PlayerPrefController.GetGatlingUpgradeAmount();
            screwBank.DisplayScrewText();

            PlayerPrefController.SetGatlingAP(gatlingDamageCurrent * 11 / 10);
            gatlingDamageCurrent = PlayerPrefController.GetGatlingAP();
            turretUIController.SetGatlingPriceAndAp();
        }
    }

    public void IncreaseFlamerAP()
    {
        if (PlayerPrefController.GetScrewBankAmount() >= PlayerPrefController.GetFlamerUpgradeAmount())
        {
            screwBank.DecreaseScrews(PlayerPrefController.GetFlamerUpgradeAmount());
            PlayerPrefController.SetFlamerUpgradeAmount(PlayerPrefController.GetFlamerUpgradeAmount() * 3 / 2);
            flamerUpgradeAmountCurrent = PlayerPrefController.GetFlamerUpgradeAmount();
            screwBank.DisplayScrewText();

            PlayerPrefController.SetFlamerAP(flamerDamageCurrent * 11 / 10);
            flamerDamageCurrent = PlayerPrefController.GetFlamerAP();
            turretUIController.SetFlamerPriceAndAp();
        }
    }

    public void SetDoubleCannonActive()
    {
        if (PlayerPrefController.GetScrewBankAmount() >= doubleCannonActivenessScrewAmount)
        {
            PlayerPrefController.SetScrewToBank(PlayerPrefController.GetScrewBankAmount() - doubleCannonActivenessScrewAmount);
            screwBank.DisplayScrewText();

            PlayerPrefController.SetDoubleCannonActiveness(1);
            doubleCannonActivenessCurrent = PlayerPrefController.GetDoubleCannonActiveness();
            turretUIController.ShowOrHideActiveness();
        }
    }

    public void SetGatlingActive()
    {
        if (PlayerPrefController.GetScrewBankAmount() >= gatlingActivenessScrewAmount)
        {
            PlayerPrefController.SetScrewToBank(PlayerPrefController.GetScrewBankAmount() - gatlingActivenessScrewAmount);
            screwBank.DisplayScrewText();

            PlayerPrefController.SetGatlingActiveness(1);
            gatlingActivenessCurrent = PlayerPrefController.GetGatlingActiveness();
            turretUIController.ShowOrHideActiveness();
        }
    }

    public void SetFlamerActive()
    {
        if (PlayerPrefController.GetScrewBankAmount() >= flamerActivenessScrewAmount)
        {
            PlayerPrefController.SetScrewToBank(PlayerPrefController.GetScrewBankAmount() - flamerActivenessScrewAmount);
            screwBank.DisplayScrewText();

            PlayerPrefController.SetFlamerActiveness(1);
            flamerActivenessCurrent = PlayerPrefController.GetFlamerActiveness();
            turretUIController.ShowOrHideActiveness();
        }
    }

    public void ResetAllAps()
    {
        PlayerPrefController.SetCannonAP(cannonDamageLV0);
        PlayerPrefController.SetDoubleCannonAP(doubleCannonDamageLV0);
        PlayerPrefController.SetGatlingAP(gatlingDamageLV0);
        PlayerPrefController.SetFlamerAP(flamerDamageLV0);

        PlayerPrefController.SetDoubleCannonActiveness(doubleCannonActivenessDefault);
        PlayerPrefController.SetGatlingActiveness(gatlingActivenessDefault);
        PlayerPrefController.SetFlamerActiveness(flamerActivenessDefault);

        PlayerPrefController.SetCannonUpgradeAmount(cannonUpgradeAmountLV0);
        PlayerPrefController.SetDoubleCannonUpgradeAmount(doubleCannonUpgradeAmountLV0);
        PlayerPrefController.SetGatlingUpgradeAmount(gatlingUpgradeAmountLV0);
        PlayerPrefController.SetFlamerUpgradeAmount(flamerUpgradeAmountLV0);

        PlayerPrefController.SetScrewToBank(screwBank.GetstartScrews());
        screwBank.DisplayScrewText();

        turretUIController.ShowOrHideActiveness();
        turretUIController.SetCannonPriceAndAp();
        turretUIController.SetDoubleCannonPriceAndAp();
        turretUIController.SetFlamerPriceAndAp();
        turretUIController.SetGatlingPriceAndAp();
    }
}
