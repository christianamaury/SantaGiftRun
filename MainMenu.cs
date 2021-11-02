using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance {get; set;}


    //..Buttons & UI Panels Game Object
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



    private void Awake()
    {
        Instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        infoPanelGameObject.SetActive(false);
    }

    public void startGame()
    {
        //..Putting Sounds here
        FindObjectOfType<AudioManager>().Play("Click");

        //..Loading Scene
        SceneManager.LoadScene(2);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void socialMediaLink()
    {
        //..Putting Sounds here
        FindObjectOfType<AudioManager>().Play("Click");

        //Opening Tik Tok Account profile..
        Application.OpenURL("https://vm.tiktok.com/ZMeNXyTSv/");
    }

    public void displayInfoMenu()
    {
        //..Button Sounds
        FindObjectOfType<AudioManager>().Play("Click");

        infoPanelGameObject.SetActive(true);

        //..Turning off these buttons
        playGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        tiktokButton.SetActive(false);
        leaderboardButton.SetActive(false);
        noAdsButton.SetActive(false);
        infoButton.SetActive(false);
        storeGameButtton.SetActive(false);
        rewardsVideoButton.SetActive(false);
    
    }

    public void backToMainMenu()
    {
        //..Putting Sounds here
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

    }


    public void quitGame()
    {
        //..Putting Sounds here
        FindObjectOfType<AudioManager>().Play("Click");

        //..Quitting Application
        Application.Quit();
    }

    public void checkOurGames()
    {
        //..Play UI Sound
        FindObjectOfType<AudioManager>().Play("Click");

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Application.OpenURL("https://apps.apple.com/us/developer/christian-a-castro/id1427156495");
        }

        if (Application.platform != RuntimePlatform.IPhonePlayer || Application.platform != RuntimePlatform.OSXPlayer)
        {
            Application.OpenURL("https://play.google.com/store/apps/developer?id=Sweetest+Productions+LLC");
        }
    }
}
