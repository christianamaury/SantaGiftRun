using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHScore : MonoBehaviour
{
    public static RedHScore Instance {get; set;}

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(GameM.Instance.redGiftSCounts > 0)
            {
                //Granting Player Health;
                StaminaBar.Instance.GrantHealth();

                //Playing Santan Claus Special Sound..
                AudioManager.Instance.Play("MerryChristmas");

                //Saving the score;
                GameM.Instance.savingActualScore();

                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();

                GameM.Instance.redGiftSCounts = GameM.Instance.redGiftSCounts - 1;

                //Updating text count;
                CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);
                CurrencySystem.Instance.healthCount += 1;
                PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);
                CurrencySystem.Instance.healthPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();
                GameM.Instance.redGiftCount.text = GameM.Instance.redGiftSCounts.ToString();
                
            }   
        }
    }
}
