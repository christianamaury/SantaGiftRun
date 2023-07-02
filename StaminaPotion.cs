using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPotion : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //..Destroy potion Game Object;
            Destroy(gameObject);

            CurrencySystem.Instance.armorCount = PlayerPrefs.GetInt("ArmorPotions", 0);
            CurrencySystem.Instance.armorCount = CurrencySystem.Instance.armorCount + 1;
            CurrencySystem.Instance.armorPotionsTextCount.text = CurrencySystem.Instance.armorCount.ToString();

            if (CurrencySystem.Instance.armorCount > PlayerPrefs.GetInt("ArmorPotions", 0))
            {
                //Setting up Potions Available;
                PlayerPrefs.SetInt("ArmorPotions", CurrencySystem.Instance.armorCount);

                //Updating Text Count..
                CurrencySystem.Instance.armorPotionsTextCount.text = PlayerPrefs.GetInt("ArmorPotions", 0).ToString();

            }

        }
    }
}
