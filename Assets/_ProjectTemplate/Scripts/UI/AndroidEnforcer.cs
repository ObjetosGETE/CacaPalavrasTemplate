using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class AndroidEnforcer : MonoBehaviour
{
    private static AndroidEnforcer _instance;

    public bool FullScreen = false;

    private FullScreen _fs;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        _instance = this;

        _fs = FindObjectOfType<FullScreen>();
    }

    private void Start()
    {
        if (IsIOS())
        {
            gameObject.SetActive(false);
            return;
        }
    }

    public void CallFullScreen()
    {
        if (IsIOS())
        {
            return;
        }

        GoFullScreen();

        if (IsAndroid())
            InvokeRepeating("GoFullScreen", 5.0f, 5.0f);
    }
    private void GoFullScreen()
    {
        if (FullScreen || Application.isEditor)
        {
            return;
        }
        FullScreen = true;
        _fs.IsOnFullScreen = true;
        ExecuteAnything("document.body.requestFullscreen()");
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