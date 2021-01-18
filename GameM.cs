using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameM : MonoBehaviour
{
    //In order to check score..., Compare which house the player has triggered with!
    //Redhouse, YellowHouse, BlueHouse, GreenHouse
    public static GameM Instance { get; set; }

    //Reference of the Gifts Counts..
    public TextMeshProUGUI redGiftCount;
    public TextMeshProUGUI greenGiftCount;
    public TextMeshProUGUI yellowGiftCount;
    public TextMeshProUGUI blueGiftCount;

    //Score Count & Best Score Count..
    public TextMeshProUGUI scoreCount;


    //public TextMeshProUGUI bestScoreCount;
    //public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScoreTransfer;

    //Count purposes..Antes tenian 1
    public int score = 0;
    public int blueGiftSCounts = 0;
    public int redGiftSCounts = 0;
    public int greenGiftSCounts = 0;
    public int yellowGiftSCounts = 0;


    public void Awake()
    {
        Instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        blueGiftCount.text = blueGiftSCounts.ToString();
        greenGiftCount.text = greenGiftSCounts.ToString();
        redGiftCount.text = redGiftSCounts.ToString();
        yellowGiftCount.text = yellowGiftSCounts.ToString();

        scoreCount.text = score.ToString();
        //bestScoreCount.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        bestScoreTransfer.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        /*
         *OLD STUFF
        //..Initialize Current Counts of the Gifts
        redGiftCount.text = PlayerPrefs.GetInt("RedGiftCounts", 0).ToString();
        greenGiftCount.text = PlayerPrefs.GetInt("GreenGiftCounts", 0).ToString();
        yellowGiftCount.text = PlayerPrefs.GetInt("YellowGiftCounts", 0).ToString();
        //blueGiftCount.text = PlayerPrefs.GetInt("BlueGiftCounts", 0).ToString();
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void redGiftCounts()
    {
        redGiftSCounts = redGiftSCounts + 1;
        redGiftCount.text = redGiftSCounts.ToString();

        /*
        giftCounts = giftCounts + 1;
        {
            if(giftCounts > PlayerPrefs.GetInt("RedGiftCounts", 0))
            {
                //Saving the Count..
                PlayerPrefs.SetInt("RedGiftCounts", giftCounts);
                //..Updating the Text..
                redGiftCount.text = giftCounts.ToString();
            }
        }
        */
    }

    public void greenGiftCounts()
    {
        greenGiftSCounts = greenGiftSCounts + 1;
        greenGiftCount.text = greenGiftSCounts.ToString();

        /*
        giftCounts = giftCounts + 1;
        if(giftCounts > PlayerPrefs.GetInt("GreenGiftCounts", 0))
        {
            //..Saving the Count
            PlayerPrefs.SetInt("GreenGiftCounts", giftCounts);
            //..Updating text
            greenGiftCount.text = giftCounts.ToString();
        }
        */
    }

    public void blueGiftCounts()
    {
        blueGiftSCounts = blueGiftSCounts + 1;
        blueGiftCount.text = blueGiftSCounts.ToString();


        /*
        if(giftCounts > PlayerPrefs.GetInt("BlueGiftCounts", 0))
        {
            //..Saving the Count
            PlayerPrefs.SetInt("BlueGiftCounts", giftCounts);
            //..Updating text
            blueGiftCount.text = giftCounts.ToString();
        }
        */

    }

    public void yellowGiftCounts()
    {
        yellowGiftSCounts = yellowGiftSCounts + 1;
        yellowGiftCount.text = yellowGiftSCounts.ToString();

        /*
        giftCounts = giftCounts + 1;
        if(giftCounts > PlayerPrefs.GetInt("YellowGiftCounts", 0))
        {
            //..Saving the Count
            PlayerPrefs.SetInt("YellowGiftCounts", giftCounts);
            //..Updating text
            yellowGiftCount.text = giftCounts.ToString();
        }
    }
        */
    }

    public void savingActualScore()
    {
        scoreCount.text = score.ToString();
        score = score + 1;
        if(score > PlayerPrefs.GetInt("BestScore", 0))
        {
            //..Saving the count
            PlayerPrefs.SetInt("BestScore", score);

            //..Updating the actual Best Score..
            //bestScoreCount.text = score.ToString();

            bestScoreTransfer.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        }
    }
}
