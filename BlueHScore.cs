using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHScore : MonoBehaviour
{
    public static BlueHScore Instance { get; set;}

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(GameM.Instance.blueGiftSCounts > 0)
            {
                //Honoring life on the player..
                StaminaBar.Instance.GrantHealth();

                //Playing santa special sound..
                AudioManager.Instance.Play("MerryChristmas");

                GameM.Instance.savingActualScore();
                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();

                GameM.Instance.blueGiftSCounts = GameM.Instance.blueGiftSCounts - 1;
                //..This will fix UI Text Count Bug;
                CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);
                CurrencySystem.Instance.healthCount += 1;
                PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);
                CurrencySystem.Instance.healthPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();

                GameM.Instance.blueGiftCount.text = GameM.Instance.blueGiftSCounts.ToString();
                
            }
        }
    }
}
