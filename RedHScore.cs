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

            if(GameM.Instance.redGiftSCounts > 0)
            {
                //..Playing santa special sound
                AudioManager.Instance.Play("MerryChristmas");
                //..Saving Actual Score
                GameM.Instance.savingActualScore();

                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();
                GameM.Instance.redGiftSCounts = GameM.Instance.redGiftSCounts - 1;
                GameM.Instance.redGiftCount.text = GameM.Instance.redGiftSCounts.ToString();

            }
        }
    }
}
