using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartLevel : MonoBehaviour
{
    public static RestartLevel Instance {get; set;}

    //Variable for Ads Purposes.,.
    private int playerDiedNumber;
    private int playerDiedRandom;

    //Reference of the Game Object Canvas..
    public GameObject restartCanvasObject;
   

    // Start is called before the first frame update
    void Start()
    {
        playerDiedNumber = 2;
        playerDiedRandom = Random.Range(1, 3);
       
        //Game will be active every single time we start the game;
        Time.timeScale = 1;
    }

    void Awake ()
    {
        Instance = this;
        //Turn off the UI Canvas when the game starts..
        restartCanvasObject.SetActive(false);
    }

    public void showingRestartMenu()
    {
        //Disabled Score Textin the Game..Mainone
        GameM.Instance.scoreCount.gameObject.SetActive(false);

        //Disabled Coins Image..
        CurrencySystem.Instance.coinsImageGameObject.SetActive(false);
        CurrencySystem.Instance.coinsText.gameObject.SetActive(false);

        //Calling Randomizer IntertitialsAds nethod.
        randomInterestialAdsShow();

        //Showing Game Menu
        restartCanvasObject.SetActive(true);

        //Pausing game.. 
        Time.timeScale = 0;

        //Animating Game Over Text;
        GOTextAnimator.Instance.PlayTextAnimation();
     
    }

    public void restartingActualLevel()
    {
        restartCanvasObject.SetActive(false);
        Time.timeScale = 1;

        //Re-loading current screen..
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void randomInterestialAdsShow()
    {
        if (playerDiedNumber == playerDiedRandom)
        {
            //Call Interestials Ads Method..
            AdsManager.Instance.showingInterestialAds();
        }
        else {return;}
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
