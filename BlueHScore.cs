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

            if(GameM.Instance.blueGiftSCounts > 0)
            {
                //..Playing santa special sound
                AudioManager.Instance.Play("MerryChristmas");

                GameM.Instance.savingActualScore();
                GameM.Instance.scoreCount.text = GameM.Instance.score.ToString();

                GameM.Instance.blueGiftSCounts = GameM.Instance.blueGiftSCounts - 1;
                GameM.Instance.blueGiftCount.text = GameM.Instance.blueGiftSCounts.ToString();
            }
        }
    }
}
