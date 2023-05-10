using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

//For Event Handlers..
using System;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance {get; set;}
    //AppID.. iOS
    private string appID = "ca-app-pub-3187572158588519~6468018463";
    //BannerID..
    private string bannerID = "ca-app-pub-3187572158588519/7017848654";

    //InterestialAd..
    private string interestialAdsUnit = "ca-app-pub-3187572158588519/3114919207";

    //..Rewards VideoAdUnit
    private string rewardVideoAds = "ca-app-pub-3187572158588519/6632579779";
    private string rewardsTestVideoAds = "ca-app-pub-3940256099942544/5354046379";

    //..Test AdsUnit
    private string testAds = "ca-app-pub-3940256099942544/2934735716";

    public int rewardedCoins = 0;

    //AppID.., Android Device
    private string appAndroidID = "ca-app-pub-3187572158588519~9232770848";
    //Android Banner ID..
    private string androidBannerID = "ca-app-pub-3187572158588519/5403182951";
    //Android Interestial Ads..
    private string androidInterestialAds = "ca-app-pub-3187572158588519/7781100136";
    //..Android RewardsVideoAds
    private string androidRewardVideoAds = "ca-app-pub-3187572158588519/7676206317";

    private BannerView bannerView;
    private InterstitialAd interestialAds;
    private RewardedAd rewardedAd;

    private void Awake()

    {
        Instance = this;

        /*
        //..When Loading another Scene, don't delete this gameObject
        //DontDestroyOnLoad(gameObject);

        #if UNITY_IOS
        //..Initialize app ID..
        MobileAds.Initialize(initStatus => { });
       

        #endif

        #if UNITY_ANDROID
        //..Initialize app ID for Android Devices..
        MobileAds.Initialize(initStatus => { });

        #endif
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_IOS
        //..Initialize app ID..
        MobileAds.Initialize(initStatus => { });
        #endif

        #if UNITY_ANDROID
        //..Initialize app ID for Android Devices..
        MobileAds.Initialize(initStatus => { });
        #endif

        int NoAdsReference = PlayerPrefs.GetInt("NoAds", 0);

        if(IAPurchase.Instance.removeAllAds_IAP == false || NoAdsReference == 0)
        {
            Debug.Log("Calling ads down here");

            //..Calling those Banners,Interestials and Rewarded Video Request
            this.requestBanner();
            this.requestingVideoAds();
            this.requestRewardedVideoAds();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void requestBanner()
    {
        #if UNITY_IOS
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);

        //Creating an empty Ad Request..
        AdRequest request = new AdRequest.Builder().Build();
        //Loading Banner..with the request
        bannerView.LoadAd(request);
        #endif

        #if UNITY_ANDROID
        bannerView = new BannerView(androidBannerID, AdSize.Banner, AdPosition.Top);
        //Creating ampty Ad Request..
        AdRequest request = new AdRequest.Builder().Build();

        //Loading Banner with the request..
        bannerView.LoadAd(request);
        #endif
    }

    public void requestRewardedVideoAds()
    {
        #if UNITY_IOS
        this.rewardedAd = new RewardedAd(rewardVideoAds);
        //..Creating an empty AdRequest
        AdRequest request = new AdRequest.Builder().Build();
        //..Loading the Rewarded ad with the request;
        this.rewardedAd.LoadAd(request);
        #endif

        #if UNITY_ANDROID
        this.rewardedAd = new RewardedAd(androidRewardVideoAds);
        //..Creating an empty AdRequest
        AdRequest request = new AdRequest.Builder().Build();
        //..Loading the Rewarded ad with the request;
        this.rewardedAd.LoadAd(request);
        #endif
    }

    public void requestingVideoAds()
    {
        #if UNITY_IOS
        this.interestialAds = new InterstitialAd(interestialAdsUnit);

        //Creating an empty AdRequest..
        AdRequest request = new AdRequest.Builder().Build();
        //Loading the Interestial Ads..
        this.interestialAds.LoadAd(request);
        #endif

        #if UNITY_ANDROID
        this.interestialAds = new InterstitialAd(androidInterestialAds);

        //..Creating an empty AdRequest...
        AdRequest request = new AdRequest.Builder().Build();

        //Load the interestial with the request..
        this.interestialAds.LoadAd(request);
        #endif
    }

    public void showingRewardedVideoAds()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }

        else {Debug.Log("Rewarded Video aren't ready to load up yet");}

        //..Rewarded Video Ads Behaviour
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    public void showingInterestialAds()
    {
        if (this.interestialAds.IsLoaded())
        {
            //..Display Ads..
            this.interestialAds.Show();
        }

        //..If isn't ready yet
        else {Debug.Log("Ads are not ready to load up yet");}

        //Interestials Ads Behaviour.. 
        this.interestialAds.OnAdOpening += HandleOnAdOpened;
        this.interestialAds.OnAdClosed += HandleOnAdClosed;
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleOnAdOpened (object sender, EventArgs args)
    {

    }

    public void HandleOnAdClosed (object sender, EventArgs args)
    {

    }

    public void HandleOnAdLeavingApplication (object sender, EventArgs args)
    {

    }

    //..Called when the user should be rewarded for interacting with the ad.. 
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        //string type = args.Type;

        double amount = args.Amount;

        int coinsAvailable = PlayerPrefs.GetInt("Currency", 0);
        rewardedCoins = (int)amount;
        coinsAvailable = coinsAvailable + rewardedCoins;

        //..Availble coins now
        PlayerPrefs.SetInt("Currency", coinsAvailable);

        //..Updating Coins Text;
        Shop.Instance.coinsText.text = PlayerPrefs.GetInt("Currency", 0).ToString() + "c";


        /*
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        */
    }
}
