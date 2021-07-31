using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Facebook.Unity;
//using AudienceNetwork;


public class HoopslyIntegration : MonoBehaviour
{
    private static HoopslyIntegration instance;
    public static HoopslyIntegration Instance
    {
        get { return instance; }
    }
    private AppsFlyerObjectScript m_appsFlyerIntegrationManager;
    private string m_uuid;

    private int interstitialRetryAttempt;
    private int rewardedRetryAttempt;
    private bool isBannerShowing;

    private AdRewardType m_currentRewardType = AdRewardType.other;

    public event Action<string> m_OnInterstitialLoadedEvent = delegate { };
    public event Action<string, MaxSdkBase.ErrorInfo> m_OnInterstitialFailedEvent = delegate { };
    public event Action<string, MaxSdkBase.ErrorInfo, MaxSdkBase.AdInfo> m_OnInterstitialFailedToDisplayEvent = delegate { };
    public event Action<string, MaxSdkBase.AdInfo> m_OnInterstitialDisplayedEvent = delegate { };
    public event Action<string, MaxSdkBase.AdInfo> m_OnInterstitialClickedEvent = delegate { };
    public event Action<string> m_OnInterstitialDismissedEvent = delegate { };

    public event Action<string, MaxSdkBase.AdInfo> m_OnRewardedAdLoadedEvent = delegate { };
    public event Action<string, MaxSdkBase.ErrorInfo> m_OnRewardedAdLoadFailedEvent = delegate { };
    public event Action<string, MaxSdkBase.ErrorInfo, MaxSdkBase.AdInfo> m_OnRewardedAdFailedToDisplayEvent = delegate { };
    public event Action<string, MaxSdkBase.AdInfo> m_OnRewardedAdDisplayedEvent = delegate { };
    public event Action<string, MaxSdkBase.AdInfo> m_OnRewardedAdClickedEvent = delegate { };
    public event Action<string, MaxSdkBase.AdInfo> m_OnRewardedAdClosedEvent = delegate { };
    public event Action<string, MaxSdk.Reward, MaxSdkBase.AdInfo, AdRewardType> m_OnRewardedAdReceivedRewardEvent = delegate { };

    #region Unity methods
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        Debug.LogWarning("StartInProgress!");
        m_uuid = GetOrGenerateUUID();
        InitSequence();
        //InitApplovin(m_uuid);
    }

    private void InitSequence()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if(HoopslySettings.Instance.UseApplovin)
                InitApplovin(m_uuid);
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            if (HoopslySettings.Instance.UseApplovin)
                InitApplovin(m_uuid);

            if (HoopslySettings.Instance.UseFirebase)
                InitFirebase(m_uuid);

            if (HoopslySettings.Instance.UseAppsflyer)
                InitAppsFlyer(m_uuid);

            if (HoopslySettings.Instance.UseFacebook)
                InitFacebookSDK();
        }
    }


    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            if(HoopslySettings.Instance.UseFacebook)
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                {
                    FB.Init(() =>
                    {
                        FB.ActivateApp();
                    });
                }
            }
        }
    }
    #endregion

    #region UUID get or generate
    private string GetOrGenerateUUID()
    {
        string uuid = "";
        if (!PlayerPrefs.HasKey("UUID"))
        {
            uuid = Guid.NewGuid().ToString();
            PlayerPrefs.SetString("UUID", uuid);
        }
        else
        {
            uuid = PlayerPrefs.GetString("UUID");
        }
        return uuid;
    }
    #endregion

    #region Firebase
    private void InitFirebase(string uuid)
    {
        Debug.Log("____________________________FIREBASE!_________________________________");
        FirebaseAnalytics.SetUserId(uuid);
        RaiseInitEvent();
    }

    public void RaiseInitEvent()
    {
        if (PlayerPrefs.HasKey("InitSended")) { return; }
        PlayerPrefs.SetInt("InitSended", 1);
        FirebaseAnalytics.LogEvent("Init", GenerateInitParameterArray());
    }


    private Parameter[] GenerateInitParameterArray()
    {
        List<Parameter> parameters = new List<Parameter>();
        parameters.Add(new Parameter("GPU", SystemInfo.graphicsDeviceName.ToString()));
        parameters.Add(new Parameter("CPU", SystemInfo.processorType.ToString()));
        parameters.Add(new Parameter("RAM", SystemInfo.systemMemorySize));
        parameters.Add(new Parameter("screen_res_x", Screen.width));
        parameters.Add(new Parameter("screen_res_y", Screen.height));
#if UNITY_IOS
        parameters.Add(new Parameter("idfv", UnityEngine.iOS.Device.vendorIdentifier));
#endif
        return parameters.ToArray();
    }

    private void RaiseAdAttemptEvent()
    {
        FirebaseAnalytics.LogEvent("ad_attempt");
    }

    private void RaiseAdWatchedEvent(MaxSdkBase.AdInfo adInfo, AdRewardType rewardType)
    {
        FirebaseAnalytics.LogEvent("ad_watched", new Parameter("ad_network", adInfo.NetworkName));
    }

    public void RaiseLevelStartEvent(string level_id)
    {
        Debug.LogWarning("Send level start event");
        FirebaseAnalytics.LogEvent("level_start", new Parameter("level_id", level_id.ToString()));
    }

    public void RaiseAdOfferEvent(AdRewardType rewardType)
    {
        FirebaseAnalytics.LogEvent("ad_offer", new Parameter("reward_Type", rewardType.ToString()));
    }

    public void RaiseLevelFinishedEvent(string level_id, LevelFinishedResult result, int playTime)
    {
        Parameter[] parameters = new Parameter[]
        {
            new Parameter("level_id", level_id.ToString()),
            new Parameter("result", result.ToString()),
            new Parameter("time", playTime)
        };
    }
    #endregion

    #region AppsFlyer Initailization
    private void InitAppsFlyer(string uuid)
    {
        Debug.Log("____________________________APPSFLYER!_________________________________");
        if (m_appsFlyerIntegrationManager != null)
        {
            m_appsFlyerIntegrationManager.InitAppsflyerSDK(uuid, HoopslySettings.Instance.AppsFlyerSdkKey, HoopslySettings.Instance.AppsflyerIsDebug, HoopslySettings.Instance.AppsFlyerAppID);
        }
        else
        {
            m_appsFlyerIntegrationManager = GetComponentInChildren<AppsFlyerObjectScript>();
            if (m_appsFlyerIntegrationManager != null)
                m_appsFlyerIntegrationManager.InitAppsflyerSDK(uuid, HoopslySettings.Instance.AppsFlyerSdkKey, HoopslySettings.Instance.AppsflyerIsDebug, HoopslySettings.Instance.AppsFlyerAppID);
            else
                Debug.LogError("Unable to find AppsFlyer to init!");
        }
    }
    #endregion

    #region Applovin
    private void InitApplovin(string uuid)
    {
        Debug.Log("____________________________APPLOVIN!_________________________________");
        if (HoopslySettings.Instance.MaxSdkKey == "")
        {
            Debug.LogWarning("Applovin MAX sdk key was not set! Initialization skipped!");
            return;
        }

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if(HoopslySettings.Instance.UseFirebase)
                    InitFirebase(m_uuid);

                if(HoopslySettings.Instance.UseAppsflyer)
                    InitAppsFlyer(m_uuid);

                if(HoopslySettings.Instance.UseFacebook)
                    InitFacebookSDK();
            }
            if (HoopslySettings.Instance.UseInterstitialAd)
                InitializeInterstitialAds();
            if (HoopslySettings.Instance.UseRewardedAd)
                InitializeRewardedAds();
            if (HoopslySettings.Instance.UseBannerAd)
                InitializeBannerAds();
            if (HoopslySettings.Instance.ShowMediationDebuggerOnLoad)
                MaxSdk.ShowMediationDebugger();
        };
        MaxSdk.SetSdkKey(HoopslySettings.Instance.MaxSdkKey);
        MaxSdk.SetUserId(uuid);
        MaxSdk.InitializeSdk();
    }
    #region Interstitial Ad Methods
    private void InitializeInterstitialAds()
    {
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialDismissedEvent;

        LoadInterstitial();
    }

    void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial(HoopslySettings.Instance.InterstitialAdUnitID);
    }

    public void ShowInterstitial()
    {
        if (MaxSdk.IsInterstitialReady(HoopslySettings.Instance.InterstitialAdUnitID))
        {
            MaxSdk.ShowInterstitial(HoopslySettings.Instance.InterstitialAdUnitID);
        }
        else
        {
            Debug.LogWarning("Ad was not redy!");
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Interstitial loaded");
        m_OnInterstitialLoadedEvent(adUnitId);
        interstitialRetryAttempt = 0;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        interstitialRetryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, interstitialRetryAttempt));
        Debug.Log("Interstitial failed to load with error code: " + errorInfo);
        m_OnInterstitialFailedEvent(adUnitId, errorInfo);
        Invoke("LoadInterstitial", (float)retryDelay);
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Interstitial failed to display with error code: " + errorInfo);
        m_OnInterstitialFailedToDisplayEvent(adUnitId, errorInfo, adInfo);
        LoadInterstitial();
    }
    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) 
    {
        Debug.Log("Interstitial ad was displayed");
        m_OnInterstitialDisplayedEvent(adUnitId, adInfo);
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) 
    {
        Debug.Log("Interstitial ad was clicked");
        m_OnInterstitialClickedEvent(adUnitId, adInfo);
    }

    private void OnInterstitialDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Interstitial dismissed");
        m_OnInterstitialDismissedEvent(adUnitId);
        LoadInterstitial();
    }
    #endregion

    #region Rewarded Ad Methods
    private void InitializeRewardedAds()
    {
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        //MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdClosedEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        LoadRewardedAd();
    }

    private void LoadRewardedAd()
    {
        MaxSdk.LoadRewardedAd(HoopslySettings.Instance.RewardedAdUnitID);
    }

    public void ShowRewarded(AdRewardType rewardType)
    {
        if (MaxSdk.IsRewardedAdReady(HoopslySettings.Instance.RewardedAdUnitID))
        {
            MaxSdk.ShowRewardedAd(HoopslySettings.Instance.RewardedAdUnitID);
            m_currentRewardType = rewardType;
            RaiseAdAttemptEvent();
        }
        else
        {
            Debug.LogWarning("AD Not ready!");
        }
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Rewarded ad loaded");
        m_OnRewardedAdLoadedEvent(adUnitId, adInfo);
        rewardedRetryAttempt = 0;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        rewardedRetryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, rewardedRetryAttempt));
        Debug.LogWarning("Rewarded ad failed to load with error code: " + errorInfo);
        m_OnRewardedAdLoadFailedEvent(adUnitId, errorInfo);
        Invoke("LoadRewardedAd", (float)retryDelay);
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        Debug.LogWarning("Rewarded ad failed to display with error code: " + errorInfo);
        m_OnRewardedAdFailedToDisplayEvent(adUnitId, errorInfo, adInfo);
        LoadRewardedAd();
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Rewarded ad displayed");
        m_OnRewardedAdDisplayedEvent(adUnitId, adInfo);
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Rewarded ad clicked");
        m_OnRewardedAdClickedEvent(adUnitId, adInfo);
    }

    private void OnRewardedAdClosedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Rewarded ad was closed. Load next reward ad");
        m_OnRewardedAdClosedEvent(adUnitId, adInfo);
        LoadRewardedAd();
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        Debug.Log("Rewarded ad received reward");
        RaiseAdWatchedEvent(adInfo, m_currentRewardType);
        m_OnRewardedAdReceivedRewardEvent(adUnitId, reward, adInfo, m_currentRewardType);
    }

    #endregion

    #region Banner Ad Methods

    private void InitializeBannerAds()
    {
        MaxSdk.CreateBanner(HoopslySettings.Instance.BannerAdUnitID, HoopslySettings.Instance.BannerPosition);
        MaxSdk.SetBannerBackgroundColor(HoopslySettings.Instance.BannerAdUnitID, HoopslySettings.Instance.BannerBackgroundColor);
    }

    public void ShowBanner()
    {
        MaxSdk.ShowBanner(HoopslySettings.Instance.BannerAdUnitID);
    }

    public void HideBanner()
    {
        MaxSdk.HideBanner(HoopslySettings.Instance.BannerAdUnitID);
    }

    private void ToggleBannerVisibility()
    {
        if (!isBannerShowing)
        {
            MaxSdk.ShowBanner(HoopslySettings.Instance.BannerAdUnitID);
        }
        else
        {
            MaxSdk.HideBanner(HoopslySettings.Instance.BannerAdUnitID);
        }
        isBannerShowing = !isBannerShowing;
    }

    #endregion

    #endregion

    #region Facebook & Audiebce Initialization
    private void InitFacebookSDK()
    {
        Debug.Log("____________________________FACEBOOK!_________________________________");
        FB.Init();
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            FB.Init(() =>
            {
                FB.ActivateApp();
            });
        }
        //InitAudienceNet();
    }

    private void InitAudienceNet()
    {
        //AudienceNetworkAds.Initialize();
    }
    #endregion

}
public enum LevelFinishedResult { win, lose, manual_restart };
public enum AdRewardType { revive, multiply, skin, bonus_level, other };
