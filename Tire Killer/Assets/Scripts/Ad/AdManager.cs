using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
    private string _adUnitRewardedId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
      private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
      private string _adUnitId = "unused";
#endif

    public static AdManager Instance { get; private set; }
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            Debug.Log("Ad Initialized");
        });
    }


    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }
    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
            RegisterEventHandlers(interstitialAd);

        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    public void LoadRewardedAd()
    {

        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(_adUnitRewardedId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
            });
    }
    public void ShowRewardedAd()
    {
        const string rewardMsg =
        "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            Debug.Log("Showing rewarded ad.");
            rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
            });

        }
        else
        {
            Debug.LogError("rewarded ad is not ready yet.");
        }
    }

    private void RegisterEventHandlers(InterstitialAd ad)
    {

        ad.OnAdFullScreenContentClosed += () =>
        {
            SceneLoader.Instance.LoadLevel(1);
            UIManager.Instance._uiState.InMenu = true;
        };

    }
}
