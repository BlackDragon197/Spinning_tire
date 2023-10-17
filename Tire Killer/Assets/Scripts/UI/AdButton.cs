using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdButton : MonoBehaviour
{
    public void ShowRewardedAd()
    {
        AdManager.Instance.ShowRewardedAd();
    }

}



