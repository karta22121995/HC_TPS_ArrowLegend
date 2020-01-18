using UnityEngine;
using UnityEngine.Advertisements;   // 引用 廣告 api

public class adsManager : MonoBehaviour
{
    private string googleID = "3436889";                   // google 專案id
    private bool testMode = true;                          // 測試模式 :允許在　unity  內測試

    private string placemnetRevival = "rewardedVideo";     // 廣告類型:復活

    private void Start()
    {
        Advertisement.Initialize(googleID, testMode);　　　　// 廣告初.初始化(id，測試模式);
    }
}
