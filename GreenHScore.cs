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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //..Honoring life on the player
            StaminaBar.Instance.GrantHealth();

            //..Removed Sound Effect fron here

            if(GameM.Instance.greenGiftSCounts > 0)
            {
                //..Playing santa special sound
                AudioManager.Instance.Play("MerryChristmas");

                //..Saving the actual Score
                GameM.Instance.savingActualScore();

                //..Updating score
                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();

                GameM.Instance.greenGiftSCounts = GameM.Instance.greenGiftSCounts - 1;
                GameM.Instance.greenGiftCount.text = GameM.Instance.greenGiftSCounts.ToString();
            }
        }
    }
}
