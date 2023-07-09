using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowHScore : MonoBehaviour
{
    public static YellowHScore Instance {get; set;}

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
              if (GameM.Instance.yellowGiftSCounts > 0)

             {
                //..Granting health to the Player;
                StaminaBar.Instance.GrantHealth();

                //Playing Santa Claus Sound;
                AudioManager.Instance.Play("MerryChristmas");

                //Saving the Actual Score
                GameM.Instance.savingActualScore();

                //Updating Scoretext..
                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();

                GameM.Instance.yellowGiftSCounts = GameM.Instance.yellowGiftSCounts - 1;

                CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);
                CurrencySystem.Instance.healthCount += 1;
                PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);
                CurrencySystem.Instance.healthPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();

                //..Updating Text TextMesh Object;
                GameM.Instance.yellowGiftCount.text = GameM.Instance.yellowGiftSCounts.ToString();
               
            }
        }  
    }
}
