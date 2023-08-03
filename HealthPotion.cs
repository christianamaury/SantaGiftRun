using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public static HealthPotion Instance {get; set;}

    public void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Health Potion Sound Effect;
            AudioManager.Instance.Play("PotionsPickUp");

            //Destroy potion Game Object;
            Destroy(gameObject);

            CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);
            CurrencySystem.Instance.healthCount = CurrencySystem.Instance.healthCount + 1;
            CurrencySystem.Instance.healthPotionsCount.text = CurrencySystem.Instance.healthCount.ToString();

            if(CurrencySystem.Instance.healthCount > PlayerPrefs.GetInt("HealthPotions", 0))
            {
                //Setting up Potions Available;
                PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);

                //Updating Text Count..
                CurrencySystem.Instance.healthPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();

            }

        }    
    }
}
