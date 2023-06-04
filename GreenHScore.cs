using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHScore : MonoBehaviour
{
    public static GreenHScore Instance { get; set;}

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
                if (GameM.Instance.greenGiftSCounts > 0)
            {
                //Adding life to the player;
                StaminaBar.Instance.GrantHealth();

                //Playing Santa Claus Voice Sound..
                AudioManager.Instance.Play("MerryChristmas");

                //Saving the actual Score..
                GameM.Instance.savingActualScore();

                //Updating scoreCount variable..
                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();
                //Removing Score from the Variable since it has been used;
                GameM.Instance.greenGiftSCounts = GameM.Instance.greenGiftSCounts - 1;

                //This will fix UI Text Count Bug..
                CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);
                CurrencySystem.Instance.healthCount += 1;
                PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);
                CurrencySystem.Instance.healthPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();

                //Adding textVaue to the TextMeshPro Text;
                GameM.Instance.greenGiftCount.text = GameM.Instance.greenGiftSCounts.ToString();
               
            }

        }
    }
}
