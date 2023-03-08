using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class MenuMobile : MonoBehaviour
{
    //[SerializeField] private BlockStarter _startGameBlock;

    [SerializeField] private Button _mobileFullScreenMsg;
    [SerializeField] private GameObject _startingScene;

    private FullScreen _fullScreen;

    private void Awake()
    {
        _fullScreen = FindObjectOfType<FullScreen>(true);
        _mobileFullScreenMsg.onClick.AddListener(HandleFullScreenButtonClicked);

        if (IsMobilePhone())
        {
            _mobileFullScreenMsg.gameObject.SetActive(true);
        }
        else
        {
             _startingScene.SetActive(true);
            _mobileFullScreenMsg.gameObject.SetActive(false);
        }
    }

    private void HandleFullScreenButtonClicked()
    {
        _mobileFullScreenMsg.gameObject.SetActive(false);
        _fullScreen.GoFullScreen();
        _startingScene.SetActive(true);
    }

    [DllImport("__Internal")]
    private static extern bool IsMobile();
    private bool IsMobilePhone()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
        return false;
    }
}
