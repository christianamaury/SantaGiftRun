using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; set; }

    //..Coins TextMesh Pro Object
    public TextMeshProUGUI coinsText;
    //public TextMeshProUGUI healtPotionsCount;
    //public TextMeshProUGUI armorPotionsCount;
    

    //..Once the coin has been picked up
    public int coinsPickUp = 0;
    public int currentCoinsAvailable;

    //..Armor and Health Points Count..
    public int healthCount = 0;
    public int armorCount = 0;

    //..Referenece of the amount of coins you can buy
    public const int MINIMUM_COINS = 300;
    public const int MEDIUM_COINS = 640;
    public const int LARGE_COINS = 1150;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //..Getting your coins Reference..
        coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";
    }

    public void BuyHealthPotions()
    {

        //..Needs to be 300, testing purposes 20
        if (PlayerPrefs.GetInt("Currency", 0) >= 300)
        {
            currentCoinsAvailable = PlayerPrefs.GetInt("Currency", 0);

            //..Taking some Coins Off from it
            currentCoinsAvailable = currentCoinsAvailable - 300;

            //..Setting Currency.
            PlayerPrefs.SetInt("Currency", currentCoinsAvailable);

            CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);

            //..Adding Health Potions..
            CurrencySystem.Instance.healthCount = CurrencySystem.Instance.healthCount + 3;

            //..Saving these Health Potions in the System
            PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);
            CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions");

            //..Updating TextMesh Object
            coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";

        }
    }

    public void BuyArmorHealthPotions()
    {
        if (PlayerPrefs.GetInt("Currency", 0) >= 300)
        {
            currentCoinsAvailable = PlayerPrefs.GetInt("Currency", 0);

            //..Taking some Coins Off from it
            currentCoinsAvailable = currentCoinsAvailable - 300;

            //..Setting Currency.
            PlayerPrefs.SetInt("Currency", currentCoinsAvailable);

            CurrencySystem.Instance.armorCount = PlayerPrefs.GetInt("ArmorPotions", 0);

            //..Adding Armor Potions..
            CurrencySystem.Instance.armorCount = CurrencySystem.Instance.armorCount + 3;

            //..Saving these Armor  Potions in the System
            PlayerPrefs.SetInt("ArmorPotions", CurrencySystem.Instance.armorCount);

            CurrencySystem.Instance.armorCount = PlayerPrefs.GetInt("ArmorPotions");
            //..Updating TextMesh Object
            coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";
        }
    }

    public void BuyMinimumCoins()
    {
            int coinsAvailable = PlayerPrefs.GetInt("Currency", 0);
            //rewardedCoins = (int)amount;
            coinsAvailable = coinsAvailable + 340;
            //..Availble coins now
            PlayerPrefs.SetInt("Currency", coinsAvailable);
            //..Updating Coins Text;
            coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";  
    }

    public void BuyMediumCoins()
    {
            int coinsAvailable = PlayerPrefs.GetInt("Currency", 0);
            //rewardedCoins = (int)amount;
            coinsAvailable = coinsAvailable + 640;
            //..Availble coins now
            PlayerPrefs.SetInt("Currency", coinsAvailable);
            //..Updating Coins Text;
            coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";
    }

    public void BuyLargeCoins()
    {
            int coinsAvailable = PlayerPrefs.GetInt("Currency", 0);
            //rewardedCoins = (int)amount;
            coinsAvailable = coinsAvailable + 1150;
            //..Availble coins now
            PlayerPrefs.SetInt("Currency", coinsAvailable);
            //..Updating Coins Text;
            coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";
    }
}
