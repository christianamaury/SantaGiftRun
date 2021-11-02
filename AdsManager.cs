using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using GoogleMobileAds.Api;

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
    private string testAds = "ca-app-pub-3940256099942544/2934735716";



    //AppID.., Android Device
    private string appAndroidID = "ca-app-pub-3187572158588519~9232770848";
    //Android Banner ID..
    private string androidBannerID = "ca-app-pub-3187572158588519/5403182951";
    //Android Interestial Ads..
    private string androidInterestialAds = "ca-app-pub-3187572158588519/7781100136";

    private BannerView bannerView;
    private InterstitialAd interestialAds;

    private void Awake()
    {
        Instance = this;

        //..When Loading another Scene, don't delete this gameObject
        DontDestroyOnLoad(gameObject);

        #if UNITY_IOS
        //..Initialize app ID..
        MobileAds.Initialize(appID);
        #endif

        #if UNITY_ANDROID
        //..Initialize app ID for Android Devices..
        MobileAds.Initialize(appAndroidID);
        #endif
    }
    // Start is called before the first frame update
    void Start()
    { 
        //..Calling those Banners and Interestials Request
        this.requestBanner();
        this.requestingVideoAds();
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
}
