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

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //..Honorng life on the player
            StaminaBar.Instance.GrantHealth();
            if (GameM.Instance.yellowGiftSCounts > 0)
            {
                //..Playing santa special sound
                AudioManager.Instance.Play("MerryChristmas");

                //..Saving the Actual Score
                GameM.Instance.savingActualScore();

                //..Updating Scoretext..
                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();

                GameM.Instance.yellowGiftSCounts = GameM.Instance.yellowGiftSCounts - 1;
                GameM.Instance.yellowGiftCount.text = GameM.Instance.yellowGiftSCounts.ToString();
            }
        }  
    }
}
