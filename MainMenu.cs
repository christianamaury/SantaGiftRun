﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance {get; set;}

    //..Buttons & UI Panels Game Object;
    public GameObject infoPanelGameObject;
    public GameObject storePanelGameObject;
    public GameObject playGameButton;
    public GameObject quitGameButton;
    public GameObject noAdsButton;
    public GameObject leaderboardButton;
    public GameObject tiktokButton;
    public GameObject rewardsVideoButton;
    public GameObject infoButton;
    public GameObject storeGameButtton;
    public GameObject restorePurchasesMessage;
    public GameObject noPurchasesMessages; 

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        infoPanelGameObject.SetActive(false);
        storePanelGameObject.SetActive(false);
        restorePurchasesMessage.SetActive(false);
        noPurchasesMessages.SetActive(false);
    }

    public void startGame()
    {
        //Putting Sounds here
        FindObjectOfType<AudioManager>().Play("Click");

        //Loading Scene..
        SceneManager.LoadScene(2);
        Time.timeScale = 1;

    }

    public void ShopMenu()
    {
        //Putting UI Sound here..
        FindObjectOfType<AudioManager>().Play("Click");

        storePanelGameObject.SetActive(true);

        //Turning off the info panel..
        infoButton.SetActive(false);
        playGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        storeGameButtton.SetActive(false);
        infoButton.SetActive(false);
        noAdsButton.SetActive(false);
        leaderboardButton.SetActive(false);
        rewardsVideoButton.SetActive(false);
        tiktokButton.SetActive(false);
    }

    public void socialMediaLink()
    {
        //..Putting UI Soundhere
        FindObjectOfType<AudioManager>().Play("Click");

        //Opening Tik Tok Account profile..
        Application.OpenURL("https://www.tiktok.com/@sweetestent");
    }

    public void displayInfoMenu()
    {
        //Button Sounds.,.
        FindObjectOfType<AudioManager>().Play("Click");

        infoPanelGameObject.SetActive(true);

        //Turning off these buttons..
        playGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        tiktokButton.SetActive(false);
        leaderboardButton.SetActive(false);
        noAdsButton.SetActive(false);
        infoButton.SetActive(false);
        storeGameButtton.SetActive(false);
        rewardsVideoButton.SetActive(false);
        storePanelGameObject.SetActive(false);
    }

    public void showRestorePurchasesMessage()
    {
        StartCoroutine(PurchasesRestoreMessage());
    }

    public  IEnumerator PurchasesRestoreMessage()
    {
        yield return new WaitForSeconds(1f);
        //Showing No Purchases Button;
        restorePurchasesMessage.SetActive(true);

        //Turning off these buttons..
        infoPanelGameObject.SetActive(false);
        playGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        tiktokButton.SetActive(false);
        leaderboardButton.SetActive(false);
        noAdsButton.SetActive(false);
        infoButton.SetActive(false);
        storeGameButtton.SetActive(false);
        rewardsVideoButton.SetActive(false);
        storePanelGameObject.SetActive(false);

        yield return new WaitForSeconds(3.2f);
        //Enabling infoPanel GameObject;
        infoPanelGameObject.SetActive(true);

        //Disabling No Purchases Button GameObject;
        restorePurchasesMessage.SetActive(false);
    }

    public void noPreviousPurchasesMessage()
    {
        StartCoroutine(DisablingMenus());
    }

    private IEnumerator DisablingMenus()
    {
        yield return new WaitForSeconds(1f);
        //Showing No Purchases Button;
        noPurchasesMessages.SetActive(true);

        //Turning off these buttons..
        infoPanelGameObject.SetActive(false);
        playGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        tiktokButton.SetActive(false);
        leaderboardButton.SetActive(false);
        noAdsButton.SetActive(false);
        infoButton.SetActive(false);
        storeGameButtton.SetActive(false);
        rewardsVideoButton.SetActive(false);
        storePanelGameObject.SetActive(false);

        yield return new WaitForSeconds(3.2f);
        //Enabling infoPanel GameObject;
        infoPanelGameObject.SetActive(true);

        //Disabling No Purchases Button GameObject;
        noPurchasesMessages.SetActive(false);


    }

    public void backToMainMenu()
    {
        //Putting Sounds here;
        FindObjectOfType<AudioManager>().Play("Click");

        //.Turning off the info panel
        infoPanelGameObject.SetActive(false);
        infoButton.SetActive(true);
        playGameButton.SetActive(true);
        quitGameButton.SetActive(true);
        storeGameButtton.SetActive(true);
        infoButton.SetActive(true);
        noAdsButton.SetActive(true);
        leaderboardButton.SetActive(true);
        rewardsVideoButton.SetActive(true);
        tiktokButton.SetActive(true);
        storePanelGameObject.SetActive(false);
    }

    public void quitGame()
    {
        //Putting Sounds here..
        FindObjectOfType<AudioManager>().Play("Click");

        //Quitting Application.,.
        Application.Quit();
    }

    public void checkOurGames()
    {
        //Play UI Sound;
        FindObjectOfType<AudioManager>().Play("Click");

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Application.OpenURL("https://apps.apple.com/us/developer/christian-a-castro/id1427156495");
        }

    }
}
