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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
              if (GameM.Instance.yellowGiftSCounts > 0)

             {
                //..Honoring life on the player
                StaminaBar.Instance.GrantHealth();

                //..Playing santa special sound
                AudioManager.Instance.Play("MerryChristmas");

                //..Saving the Actual Score
                GameM.Instance.savingActualScore();

                //..Updating Scoretext..
                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();

                GameM.Instance.yellowGiftSCounts = GameM.Instance.yellowGiftSCounts - 1;
                //..This will fix UI Text Count Bug;
                CurrencySystem.Instance.healthCount = PlayerPrefs.GetInt("HealthPotions", 0);
                CurrencySystem.Instance.healthCount += 1;
                PlayerPrefs.SetInt("HealthPotions", CurrencySystem.Instance.healthCount);
                CurrencySystem.Instance.healthPotionsCount.text = PlayerPrefs.GetInt("HealthPotions", 0).ToString();

                GameM.Instance.yellowGiftCount.text = GameM.Instance.yellowGiftSCounts.ToString();
               
            }
        }  
    }
}
