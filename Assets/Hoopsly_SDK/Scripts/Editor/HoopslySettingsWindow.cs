using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using AppLovinMax.Scripts.IntegrationManager.Editor;
using Facebook.Unity.Settings;

public class HoopslySettingsWindow : EditorWindow
{
    private GUIStyle titleLabelStyle;
    private GUIStyle TitleLableStyle
    {
        get
        {
            if(titleLabelStyle==null)
            {
                titleLabelStyle = new GUIStyle(EditorStyles.label)
                {
                    fontSize = 14,
                    fontStyle = FontStyle.Bold,
                    fixedHeight = 20
                };
            }
            return titleLabelStyle;
        }
    }
    private GUIStyle headerLabelStyle;
    private GUIStyle HeaderLableStyle
    {
        get
        {
            if(headerLabelStyle == null)
            {
                headerLabelStyle = new GUIStyle(EditorStyles.label)
                {
                    fontSize = 12,
                    fontStyle = FontStyle.Bold,
                    fixedHeight = 18
                };
            }
            return headerLabelStyle;
        }
    }

    [MenuItem("Hoopsly/Settings")]
    static void Init()
    {
        HoopslySettingsWindow window = (HoopslySettingsWindow)EditorWindow.GetWindow(typeof(HoopslySettingsWindow),false, "Hoopsly settings window");
        window.Show();
    }

    private void OnDestroy()
    {
        SaveSettingsAsset();
    }


    private void Awake()
    {
    }

    void OnGUI()
    {
        if (HoopslySettings.Instance != null)
        {
            GUILayout.Space(10);
            DrawBaseSettings();
            GUILayout.Space(10);
            DrawFirebaseSettings();
            GUILayout.Space(10);
            DrawAppsFlyerSettings();
            GUILayout.Space(10);
            DrawApplovinSettings();
            GUILayout.Space(10);
            DrawFacebookSettings();

            if (GUI.changed)
            {
                SaveSettingsAsset();
            }
        }
    }


    private void DrawBaseSettings()
    {
        GUILayout.Label("Hoopsly settings", TitleLableStyle);
        using (var v = new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Space(15);
            if (GUILayout.Button("Spawn integration prefab in current scene"))
            {
                SpawnIntegraionsPrefab();
            }
            GUILayout.Space(15);
        }
    }

    private void DrawFirebaseSettings()
    {
        GUILayout.Label("Firebase settings", TitleLableStyle);
        using (var v = new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Space(15);
            HoopslySettings.Instance.UseFirebase = EditorGUILayout.ToggleLeft("Enable Firebase SDK", HoopslySettings.Instance.UseFirebase);
            GUILayout.Space(15);
        }
    }

    private void DrawAppsFlyerSettings()
    {
        GUILayout.Label("Appsflyer settings", TitleLableStyle);
        using (var v = new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Space(15);
            HoopslySettings.Instance.UseAppsflyer = EditorGUILayout.ToggleLeft("Enable Appsflyer SDK", HoopslySettings.Instance.UseAppsflyer);
            if (HoopslySettings.Instance.UseAppsflyer)
            {
                GUILayout.Space(15);
                HoopslySettings.Instance.AppsFlyerSdkKey = EditorGUILayout.TextField("Appsflyer SDK key", HoopslySettings.Instance.AppsFlyerSdkKey);
                GUILayout.Space(5);
                HoopslySettings.Instance.AppsFlyerAppID = EditorGUILayout.TextField("AppsFlyer App ID", HoopslySettings.Instance.AppsFlyerAppID);
                GUILayout.Space(5);
                HoopslySettings.Instance.AppsflyerIsDebug = EditorGUILayout.Toggle("Is Debug", HoopslySettings.Instance.AppsflyerIsDebug);
            }
            GUILayout.Space(15);
        }
    }

    private void DrawApplovinSettings()
    {
        GUILayout.Label("Applovin MAX settings", TitleLableStyle);
        using (var v = new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Space(15);
            HoopslySettings.Instance.UseApplovin = EditorGUILayout.ToggleLeft("Enable Applovin SDK", HoopslySettings.Instance.UseApplovin);

            if (HoopslySettings.Instance.UseApplovin)
            {
                GUILayout.Space(15);
                HoopslySettings.Instance.MaxSdkKey = EditorGUILayout.TextField("Applovin MAX SDK key", HoopslySettings.Instance.MaxSdkKey);
                AppLovinSettings.Instance.SdkKey = HoopslySettings.Instance.MaxSdkKey;
                GUILayout.Space(5);

                HoopslySettings.Instance.EnableVerboseLogging = EditorGUILayout.ToggleLeft("Enable Verbose Logging", HoopslySettings.Instance.EnableVerboseLogging);
                GUILayout.Space(5);
                HoopslySettings.Instance.ShowMediationDebuggerOnLoad = EditorGUILayout.ToggleLeft(new GUIContent("Show Mediation debugger on app start"), HoopslySettings.Instance.ShowMediationDebuggerOnLoad);

                GUILayout.Space(10);

                HoopslySettings.Instance.UseInterstitialAd = EditorGUILayout.BeginToggleGroup("Enable interstitial AD", HoopslySettings.Instance.UseInterstitialAd);
                HoopslySettings.Instance.InterstitialAdUnitID = EditorGUILayout.TextField("Interstitial AD Unit ID", HoopslySettings.Instance.InterstitialAdUnitID);
                EditorGUILayout.EndToggleGroup();

                GUILayout.Space(5);
                HoopslySettings.Instance.UseRewardedAd = EditorGUILayout.BeginToggleGroup("Enable Rewarded AD", HoopslySettings.Instance.UseRewardedAd);
                HoopslySettings.Instance.RewardedAdUnitID = EditorGUILayout.TextField("Rewarded AD Unit ID", HoopslySettings.Instance.RewardedAdUnitID);
                EditorGUILayout.EndToggleGroup();

                GUILayout.Space(5);
                HoopslySettings.Instance.UseBannerAd = EditorGUILayout.BeginToggleGroup("Enable Banner AD", HoopslySettings.Instance.UseBannerAd);
                HoopslySettings.Instance.BannerAdUnitID = EditorGUILayout.TextField("Banner AD Unit ID", HoopslySettings.Instance.BannerAdUnitID);
                GUILayout.Space(5);
                HoopslySettings.Instance.BannerPosition = (MaxSdk.BannerPosition)EditorGUILayout.EnumPopup("Select banner position", HoopslySettings.Instance.BannerPosition);
                GUILayout.Space(5);
                HoopslySettings.Instance.BannerBackgroundColor = EditorGUILayout.ColorField("Background color", HoopslySettings.Instance.BannerBackgroundColor);
                EditorGUILayout.EndToggleGroup();

                GUILayout.Space(10);

                if (GUILayout.Button("Open Applovin integration manager"))
                {
                    AppLovinIntegrationManagerWindow.ShowManager();
                }
            }
            GUILayout.Space(15);
        }
    }

    private void DrawFacebookSettings()
    {
        GUILayout.Label("Facebook settings", TitleLableStyle);
        using (var v = new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Space(15);
            HoopslySettings.Instance.UseFacebook = EditorGUILayout.ToggleLeft("Enable Facebook SDK", HoopslySettings.Instance.UseFacebook);
            if(HoopslySettings.Instance.UseFacebook)
            {
                if (GUILayout.Button("Open facebook settings"))
                {
                    FacebookSettings facebookSettings = Resources.Load("FacebookSettings") as FacebookSettings;
                    EditorGUIUtility.PingObject(facebookSettings);
                    Selection.activeObject = facebookSettings;
                }
            }
            GUILayout.Space(15);
        }
    }

    //private void DrawSegmentExample()
    //{
    //    using (var v = new EditorGUILayout.VerticalScope("box"))
    //    {
    //        GUILayout.Label("I'm inside the button");
    //        GUILayout.Label("So am I");
    //        GUILayout.Label("And I");
    //        //GUILayout.Button("And i am a button!");
    //        if (GUILayout.Button("Some Action"))
    //        {
    //            DebugPathValue();
    //        }
    //    }
    //}


    private void SaveSettingsAsset()
    {
        HoopslySettings.Instance.SaveSettingsAsync();
    }

    private void SpawnIntegraionsPrefab()
    {
        HoopslyIntegration integrations = FindObjectOfType<HoopslyIntegration>();
        if (integrations == null)
        {
            GameObject instance = Resources.Load("HoopslySDK_Integrations", typeof(GameObject)) as GameObject;
            var prefab =PrefabUtility.InstantiatePrefab(instance);
            EditorUtility.SetDirty(prefab);
        }
        else
        {
            Debug.Log("Integrations pprfab already in scene");
        }
    }
}
