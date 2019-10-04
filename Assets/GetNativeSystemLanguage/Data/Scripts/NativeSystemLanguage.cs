using System;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;

public class NativeSystemLanguage
{
    public static string GetSystemLanguag()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                return IPhoneLanguage();
            case RuntimePlatform.Android:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
            default:
                return WindowsLanguage();
        }
    }

    private static string IPhoneLanguage()
    {
        return GetNativeSystemLanguage(CurIOSLang);
    }

    [DllImport("__Internal")]
    private static extern string CurIOSLang();

    private static string WindowsLanguage()
    {
        return GetNativeSystemLanguage(GetWindowsCultureInfoName);
    }

    private static string GetWindowsCultureInfoName()
    {
        return CultureInfo.GetCultureInfo(GetSystemDefaultLCID()).Name;
    }

    [DllImport("KERNEL32.DLL")]
    private static extern int GetSystemDefaultLCID();

    private static string GetNativeSystemLanguage(Func<string> GetNativeLanguageMethod)
    {
        try
        {
            return GetTransformLanguage(GetNativeLanguageMethod());
        }
        catch
        {
            return "zh-CN";
        }
    }

    private static string GetTransformLanguage(string systemLanguage)
    {
        string LangLower = systemLanguage.ToLower();

        switch (LangLower)
        {
            case "zh-cn":
            case "zh-sg":
            case "zh-chs":
            case "zh-hans":
            case "zh-hans-hk":
            case "zh-hans-mo":
            case "zh-hans-tw":
            case "chinese":
            case "chinesesimplified":
                return "CN";

            case "zh-hk":
            case "zh-mo":
            case "zh-cht":
            case "zh-tw":
            case "zh-hant":
            case "zh-hant-cn":
            case "zh-hant-hk":
            case "zh-hant-mo":
            case "zh-hant-sg":
            case "zh-hant-tw":
            case "chinesetraditional":
                return "TW";

            case "ja":
            case "ja-JP":
            case "Japanese":
                return "JP";
            default:
                return GetLanguageFamily(LangLower);
        }

    }
    private static string GetLanguageFamily(string systemLanguage)
    {
        if (systemLanguage.Contains("zh"))
            return "CN";
        else if (systemLanguage.Contains("jp"))
            return "JP";
        else
            return "EN";
    }
}
