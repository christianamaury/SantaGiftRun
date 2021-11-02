﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; set; }


    //..Coins TextMesh Pro Object
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI healtPotionsCount;
    public TextMeshProUGUI armorPotionsCount;
    

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

        //..Health Potions Available
        healtPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();

        //..Armor Potions Available..
        armorPotionsCount.text = PlayerPrefs.GetInt("ArmorPotions", 0).ToString();
    }



    public void BuyHealthPotions()
    {
        if (PlayerPrefs.GetInt("Currency", 0) >= 300)
        {
            currentCoinsAvailable = PlayerPrefs.GetInt("Currency", 0);

            //..Taking some Coins Off from it
            currentCoinsAvailable = currentCoinsAvailable - 300;

            //..Setting Currency.
            PlayerPrefs.SetInt("Currency", currentCoinsAvailable);

            //..Adding Health Potions..
            healthCount = healthCount + 3;

            //..Saving these Health Potions in the System
            PlayerPrefs.SetInt("HealthPotions", healthCount);

            //..Updating our Text Count Layer.. 
            healtPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();

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

            //..Adding Health Potions..
            armorCount = armorCount + 3;

            //..Saving these Health Potions in the System
            PlayerPrefs.SetInt("ArmorPotions", armorCount);

            //..Updating our Text Count Layer.. 
            armorPotionsCount.text = PlayerPrefs.GetInt("ArmorPotions", 0).ToString();

            //..Updating TextMesh Object
            coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
