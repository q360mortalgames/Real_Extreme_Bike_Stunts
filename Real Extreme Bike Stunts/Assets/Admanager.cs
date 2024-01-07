using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Admanager : MonoBehaviour {

    public static Admanager instance;

    private string appID = "ca-app-pub-9012998343873422~4315943909";

    private BannerView bannerView;
    private string bannerID = "notused";

    private InterstitialAd fullScreenAd;
  //  private string fullScreenAdID = "ca-app-pub-9012998343873422/3045503887";  original
    private string fullScreenAdID = "ca-app-pub-9012998343873422/9485371188";

    private RewardBasedVideoAd rewardedAd;
  //  private string rewardedAdID = "ca-app-pub-9012998343873422/7344675697"; //original
    private string rewardedAdID = "not used";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        RequestFullScreenAd();

        rewardedAd = RewardBasedVideoAd.Instance;

        RequestRewardedAd();


        rewardedAd.OnAdLoaded += HandleRewardBasedVideoLoaded;

        rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;

        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
    }


    public void RequestBanner()
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);

        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void RequestFullScreenAd()
    {
        fullScreenAd = new InterstitialAd(fullScreenAdID);

        AdRequest request = new AdRequest.Builder().Build();

        fullScreenAd.LoadAd(request);

    }

    public void ShowFullScreenAd()
    {
        if (fullScreenAd.IsLoaded())
        {
            fullScreenAd.Show();
        }else
        {
            Debug.Log("Full screen ad not loaded");
        }
    }

    public void RequestRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request, rewardedAdID);
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }else
        {
            Debug.Log("Rewarded ad not loaded");
        }
    }



    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video ad loaded successfully");
     //  UI_handlerScript.Instance. ResetAfterVidoe();

    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Failed to load rewarded video ad : " + args.Message);
     //   UI_handlerScript.Instance.ShowLevelFailed();


    }



    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("You have been rewarded with  " + amount.ToString() + " " + type);

        //  UIManager.instance.RewardPanel.SetActive(true);
        //  UIManager.instance.GameOverUI.SetActive(false);
      
     //  UI_handlerScript.Instance. mg_LifeObj.SetActive(false);
     // LevelManagerScript.Instance.Call_AddLifeAfterVideoSuccess();  //venkat
    }


    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        Debug.Log ("Rewarded video has closed");
        RequestRewardedAd();
      //  UI_handlerScript.Instance.ShowLevelFailed();
    }
}
