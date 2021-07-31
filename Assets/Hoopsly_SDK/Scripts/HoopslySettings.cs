using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;
using System.IO;

[System.Serializable]
public class HoopslySettings : ScriptableObject
{
    [Tooltip("ENTER_APPSFLYER_SDK_KEY_HERE")]
    [SerializeField] private bool m_useAppsflyer = false;
    [SerializeField] private string m_appsflyerSdkKey = "";
    [SerializeField] private string m_appsflyerAppId = "";
    [SerializeField] private bool m_appsflyerIsDebug = false;

    [Tooltip("ENTER_MAX_SDK_KEY_HERE")]
    [SerializeField] private bool m_useApplovin = false;
    [SerializeField] private string m_maxSdkKey = "";

    [Tooltip("ENABLE_APPLOVIN_VERBOSE_LOGGING")]
    [SerializeField] private bool m_enableVerboseLogging = false;

    [SerializeField] private bool m_showMediationDebuggerOnStart = false;

    [SerializeField] private bool m_useInterstitialAd;
    [Tooltip("ENTER_INTERSTITIAL_AD_UNIT_ID_HERE")]
    [SerializeField] private string m_interstitialAdUnitId = "";

    [SerializeField] private bool m_useRewardedAd;
    [Tooltip("ENTER_REWARD_AD_UNIT_ID_HERE")]
    [SerializeField] private string m_rewardedAdUnitId = "";

    [SerializeField] private bool m_useBannerAd;
    [Tooltip("ENTER_BANNER_AD_UNIT_ID_HERE")]
    [SerializeField] private string m_bannerAdUnitId = "";
    [SerializeField] private MaxSdkBase.BannerPosition m_bannerPosition = MaxSdkBase.BannerPosition.BottomCenter;
    [SerializeField] private Color m_bannerBackgroundColor = Color.black;

    [SerializeField] private bool m_useFacebook = false;
    [SerializeField] private bool m_useFirebase = false;

    public bool UseAppsflyer
    {
        get { return Instance.m_useAppsflyer; }
        set { Instance.m_useAppsflyer = value; }
    }

    public string AppsFlyerSdkKey
    {
        get { return Instance.m_appsflyerSdkKey; }
        set { Instance.m_appsflyerSdkKey = value; }
    }

    public string AppsFlyerAppID
    {
        get { return Instance.m_appsflyerAppId; }
        set { Instance.m_appsflyerAppId = value; }
    }

    public bool AppsflyerIsDebug
    {
        get { return Instance.m_appsflyerIsDebug; }
        set { Instance.m_appsflyerIsDebug = value; }
    }

    public bool UseApplovin
    {
        get { return Instance.m_useApplovin; }
        set { Instance.m_useApplovin = value; }
    }

    public string MaxSdkKey
    {
        get { return Instance.m_maxSdkKey; }
        set { Instance.m_maxSdkKey = value; }
    }

    public bool EnableVerboseLogging
    {
        get { return Instance.m_enableVerboseLogging; }
        set { Instance.m_enableVerboseLogging = value; }
    }

    public bool ShowMediationDebuggerOnLoad
    {
        get { return Instance.m_showMediationDebuggerOnStart; }
        set { Instance.m_showMediationDebuggerOnStart = value; }
    }

    public bool UseInterstitialAd
    {
        get { return Instance.m_useInterstitialAd; }
        set { Instance.m_useInterstitialAd = value; }
    }

    public bool UseRewardedAd
    {
        get { return Instance.m_useRewardedAd; }
        set { Instance.m_useRewardedAd = value; }
    }

    public bool UseBannerAd
    {
        get { return Instance.m_useBannerAd; }
        set { Instance.m_useBannerAd = value; }
    }

    public string InterstitialAdUnitID
    {
        get { return Instance.m_interstitialAdUnitId; }
        set { Instance.m_interstitialAdUnitId = value; }
    }

    public string RewardedAdUnitID
    {
        get { return Instance.m_rewardedAdUnitId; }
        set { Instance.m_rewardedAdUnitId = value; }
    }

    public string BannerAdUnitID
    {
        get { return Instance.m_bannerAdUnitId; }
        set { Instance.m_bannerAdUnitId = value; }
    }

    public MaxSdk.BannerPosition BannerPosition
    {
        get { return Instance.m_bannerPosition; }
        set { Instance.m_bannerPosition = value; }
    }

    public Color BannerBackgroundColor
    {
        get { return Instance.m_bannerBackgroundColor; }
        set { Instance.m_bannerBackgroundColor = value; }
    }

    public bool UseFacebook
    {
        get { return Instance.m_useFacebook; }
        set { Instance.m_useFacebook = value; }
    }

    public bool UseFirebase
    {
        get { return Instance.m_useFirebase; }
        set { Instance.m_useFirebase = value; }
    }

    private const string settingsAssetPath = "Assets/Hoopsly_SDK/Resources/HoopslySettings.asset";
    private static HoopslySettings instance;
    public static HoopslySettings Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.Load("HoopslySettings") as HoopslySettings;
                if (instance != null)
                {
                    return instance;
                }
#if UNITY_EDITOR
                else
                {
                    instance = CreateInstance<HoopslySettings>();
                    AssetDatabase.CreateAsset(instance, settingsAssetPath);
                }
#endif
            }
            return instance;
        }
    }

    public void SaveSettingsAsync()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(instance);
        AssetDatabase.Refresh();
#endif
    }

}
