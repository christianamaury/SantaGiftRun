﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameM : MonoBehaviour
{
    //..Reference of the GameM script; 
    public static GameM Instance { get; set; }

    //In order to check on which house the player went in;
    //Redhouse, YellowHouse, BlueHouse, GreenHouse for points purposes;
    //Reference of the Gifts Counts..
    public TextMeshProUGUI redGiftCount;
    public TextMeshProUGUI greenGiftCount;
    public TextMeshProUGUI yellowGiftCount;
    public TextMeshProUGUI blueGiftCount;

    //Game Instructions TextMesh
    public TextMeshProUGUI gameInstructions;
    public TextMeshProUGUI gamePresentsInstructions; 

    //Score Count & Best Score Count..
    public TextMeshProUGUI scoreCount;

    public TextMeshProUGUI bestScoreTransfer;

    //Variables for counting purposes;
    public int score = 0;
    public int blueGiftSCounts = 0;
    public int redGiftSCounts = 0;
    public int greenGiftSCounts = 0;
    public int yellowGiftSCounts = 0;

    private bool gameInstructionsBool = false;

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
        bestScoreTransfer.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        //Disabling GPresents TextMesh Animator Componet for now; TESTING*
        GPresentsInstructions.Instance.anim.enabled = false;

        //Co-Routine to Disable Game Text Instructions.. in 4.5 seconds;
        StartCoroutine(DisableGameTextInstructions(4.5f));

        //Game Presents Text TextMeshPro Object is Disabled by Default..
        gamePresentsInstructions.enabled = false;

    }

    private void Update()
    {
        //Co-Routine to Disable Game Presents Instructions.. in 6.9 seconds
        if (gameInstructionsBool)
        {
            StartCoroutine(DisableGamePresentsInstructions(7.9f));
            gameInstructionsBool = false;
        }
        else
        {
        
        }
    }

    //..Disabling Game Intructions Text Mesh in 4.5 seconds;
    private IEnumerator DisableGameTextInstructions(float seconds)
    {
        //Waiting time..
        yield return new WaitForSeconds(seconds);

        //Disabling TextMesh...
        GameInstruction.Instance.StopAnimatingText();
        gameInstructions.enabled = false;
        gameInstructionsBool = true;

        //Enabling GPresents TextMesh Animator Componet for now; TESTING*
        GPresentsInstructions.Instance.anim.enabled = true;
    }

    private IEnumerator DisableGamePresentsInstructions(float seconds)
    {
        if (gameInstructionsBool)
        {
            //Waiting Initial Seconds;
            yield return new WaitForSeconds(seconds);
          
            //Enabling TextMeshPro Text;
            gamePresentsInstructions.enabled = true;
            
            yield return new WaitForSeconds(seconds);
     
            //Disabling TextMesh Text Layer;
            gamePresentsInstructions.enabled = false;

            //Disabling TextMesh Text Animation;
            GPresentsInstructions.Instance.StopTextAnimation();

            //Setting if statement check variable to false;
            gameInstructionsBool = false;
        }

    }

    public void redGiftCounts()
    {
        redGiftSCounts = redGiftSCounts + 1;
        redGiftCount.text = redGiftSCounts.ToString();
    }

    public void greenGiftCounts()
    {
        greenGiftSCounts = greenGiftSCounts + 1;
        greenGiftCount.text = greenGiftSCounts.ToString();
    }

    public void blueGiftCounts()
    {
        blueGiftSCounts = blueGiftSCounts + 1;
        blueGiftCount.text = blueGiftSCounts.ToString();
    }

    public void yellowGiftCounts()
    {
        yellowGiftSCounts = yellowGiftSCounts + 1;
        yellowGiftCount.text = yellowGiftSCounts.ToString();
    }

    public void savingActualScore()
    {
        scoreCount.text = score.ToString();
        score = score + 1;
        if(score > PlayerPrefs.GetInt("BestScore", 0))
        {
            //Saving the Best Count Data;
            PlayerPrefs.SetInt("BestScore", score);

            //Saving Bestscore into the Leaderboard..
            CloudOnceServices.Instance.SubmitScoreToLeaderboard(score);

            //Transferring BestScore, Updating it;
            bestScoreTransfer.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        }
        
    }

    public void tikTokProfile()
    {
        MainMenu.Instance.socialMediaLink();
    }

    public void QuitGame()
    {
        MainMenu.Instance.quitGame();
    }

    public void backToMainScreenMenu()
    {
        //Play UI sound whenever a player click on the menu
        FindObjectOfType<AudioManager>().Play("Click");

        //Loading Scene..
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void seeOurGames()
    {
        MainMenu.Instance.checkOurGames();
    }


}
