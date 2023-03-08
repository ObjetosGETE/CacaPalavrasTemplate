using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FullScreen : MonoBehaviour
{
    private Button _button;
    private AndroidEnforcer _androidEnforcer;

    public bool IsOnFullScreen = false;

    private void Awake()
    {
        _androidEnforcer = FindObjectOfType<AndroidEnforcer>();
    }

    private void Start()
    {
        if (IsIOS())
        {
            gameObject.SetActive(false);
            return;
        }

        _button = GetComponent<Button>();
        _button.onClick.AddListener(ToggleFullScreen);
    }

    private void ToggleFullScreen()
    {
        if (IsIOS())
        {
            return;
        }

        if (IsOnFullScreen)
        {
            _androidEnforcer.FullScreen = false;
            IsOnFullScreen = false;
            ExecuteAnything("document.exitFullscreen()");
        }
        else
        {
            GoFullScreen();
        }
    }

    public  void FullScreenButton()
    {
        _androidEnforcer.CallFullScreen();
        /*
        GoFullScreen();

        if (IsAndroid())
            InvokeRepeating("GoFullScreen", 5.0f, 5.0f);*/
    }
    public void GoFullScreen()
    {
        if (IsIOS())
        {
            return;
        }

        if (IsOnFullScreen || Application.isEditor)
        {
            return;
        }
        _androidEnforcer.FullScreen = true;
        IsOnFullScreen = true;
        if (!IsIOS())
        {
            ExecuteAnything("document.body.requestFullscreen()");
        }
    }

    [DllImport("__Internal")]
    private static extern bool IsMobile();

    [DllImport("__Internal")]
    private static extern bool IsAndroidBrowser();

    [DllImport("__Internal")]
    private static extern bool IsIOSBrowser();


    public bool IsAndroid()
    {

#if !UNITY_EDITOR && UNITY_WEBGL
             return IsAndroidBrowser();
#endif
        return false;
    }


    public bool IsIOS()
    {

#if !UNITY_EDITOR && UNITY_WEBGL
             return IsIOSBrowser();
#endif
        return false;
    }

    [DllImport("__Internal")]
    private static extern void ExecuteAnything(string command);

}