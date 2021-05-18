using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefController : MonoBehaviour
{
    const string CANNONN_AP_KEY = "cannon ap";
    const string DOUBLE_CANNONN_AP_KEY = "double cannon ap";
    const string GATLING_AP_KEY = "gatling ap";
    const string FLAMER_AP_KEY = "flamer ap";

    const string IS_DOUBLE_CANNON_ACTIVE = "double cannon active";
    const string IS_GATLING_ACTIVE = "gatling active";
    const string IS_FLAMER_ACTIVE = "flamer active";

    const string CANNON_UPGRADE_AMOUNT = "cannon upgrade";
    const string DOUBLE_CANNON_UPGRADE_AMOUNT = "double cannon upgrade";
    const string GATLING_UPGRADE_AMOUNT = "gatling upgrade";
    const string FLAMER_UPGRADE_AMOUNT = "flamer upgrade";

    const string SCREW_BANK_AMOUNT = "screw bank";

    public static void SetScrewToBank(int screwAmount)
    {
        PlayerPrefs.SetInt(SCREW_BANK_AMOUNT, screwAmount);
    }

    public static int GetScrewBankAmount()
    {
        return PlayerPrefs.GetInt(SCREW_BANK_AMOUNT);
    }

    // Set Upgrade Amounts of turrets
    public static void SetCannonUpgradeAmount(int amount)
    {
        PlayerPrefs.SetInt(CANNON_UPGRADE_AMOUNT, amount);
    }
    public static void SetDoubleCannonUpgradeAmount(int amount)
    {
        PlayerPrefs.SetInt(DOUBLE_CANNON_UPGRADE_AMOUNT, amount);
    }
    public static void SetGatlingUpgradeAmount(int amount)
    {
        PlayerPrefs.SetInt(GATLING_UPGRADE_AMOUNT, amount);
    }
    public static void SetFlamerUpgradeAmount(int amount)
    {
        PlayerPrefs.SetInt(FLAMER_UPGRADE_AMOUNT, amount);
    }

    // Get Upgrade Amounts of turrets
    public static int GetCannonUpgradeAmount()
    {
        return PlayerPrefs.GetInt(CANNON_UPGRADE_AMOUNT);
    }
    public static int GetDoubleCannonUpgradeAmount()
    {
        return PlayerPrefs.GetInt(DOUBLE_CANNON_UPGRADE_AMOUNT);
    }
    public static int GetGatlingUpgradeAmount()
    {
        return PlayerPrefs.GetInt(GATLING_UPGRADE_AMOUNT);
    }
    public static int GetFlamerUpgradeAmount()
    {
        return PlayerPrefs.GetInt(FLAMER_UPGRADE_AMOUNT);
    }
    // Setting Turrets Ap's
    public static void SetCannonAP(int towerAp)
    {
        Debug.Log("C Ap: " + towerAp);
        PlayerPrefs.SetInt(CANNONN_AP_KEY, towerAp);
    }

    public static void SetDoubleCannonAP(int towerAp)
    {
        Debug.Log("DC Ap: " + towerAp);
        PlayerPrefs.SetInt(DOUBLE_CANNONN_AP_KEY, towerAp);
    }

    public static void SetGatlingAP(int towerAp)
    {
        Debug.Log("Gatling Ap: " + towerAp);
        PlayerPrefs.SetInt(GATLING_AP_KEY, towerAp);
    }

    public static void SetFlamerAP(int towerAp)
    {
        Debug.Log("Flamer Ap: " + towerAp);
        PlayerPrefs.SetInt(FLAMER_AP_KEY, towerAp);
    }

    // Get Turret Ap'S
    public static int GetCannonAP()
    {
        return PlayerPrefs.GetInt(CANNONN_AP_KEY);
    }

    public static int GetDoubleCannonAP()
    {
        return PlayerPrefs.GetInt(DOUBLE_CANNONN_AP_KEY);
    }

    public static int GetGatlingAP()
    {
        return PlayerPrefs.GetInt(GATLING_AP_KEY);
    }

    public static int GetFlamerAP()
    {
        return PlayerPrefs.GetInt(FLAMER_AP_KEY);
    }

    // Setting Turret Activeness
    public static void SetDoubleCannonActiveness(int isActive)
    {        
        PlayerPrefs.SetInt(IS_DOUBLE_CANNON_ACTIVE, isActive);
    }

    public static void SetGatlingActiveness(int isActive)
    {
        PlayerPrefs.SetInt(IS_GATLING_ACTIVE, isActive);
    }

    public static void SetFlamerActiveness(int isActive)
    {
        PlayerPrefs.SetInt(IS_FLAMER_ACTIVE, isActive);
    }

    //Get Turrets Activeness
    public static int GetDoubleCannonActiveness()
    {
        return PlayerPrefs.GetInt(IS_DOUBLE_CANNON_ACTIVE);
    }

    public static int GetGatlingActiveness()
    {
        return PlayerPrefs.GetInt(IS_GATLING_ACTIVE);
    }

    public static int GetFlamerActiveness()
    {
        return PlayerPrefs.GetInt(IS_FLAMER_ACTIVE);
    }
}
