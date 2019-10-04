using UnityEngine;
using UnityEngine.UI;

public class DisplaySystemLanguage : MonoBehaviour
{
    public Text Text;
    private void Start()
    {
        string ApplicationName = "Application: " + Application.systemLanguage.ToString();
        string NativeName = "Native: " + MobilePhoneSystemLanguageName();
        Text.text = ApplicationName + "\n" +
                    NativeName;
    }

    private string MobilePhoneSystemLanguageName()
    {
        string result = "";
        try
        {
            result = NativeSystemLanguage.GetSystemLanguag();
        }
        catch
        {

        }
        return result;
    }
}
