using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _openMenuButton;
    [SerializeField] private Button _closeMenuButton;
    [SerializeField] private Button _closeMenuBottonButton;

    [SerializeField] private Button _restoreDefaultVideoSettingsButton;

    [Header("Open Configs Buttons")]
    [SerializeField] private Button _graphicsConfigButton;
    [SerializeField] private Button _audioConfigButton;
    [SerializeField] private Button _controllerConfigButton;
/*
    [Header("UI Refferences")]
    [SerializeField] private RectTransform _sideMenu;*/

    [Header("PopUps")]
    [SerializeField] private LeanTweanerPopUp _graphicsConfigPopup;
    [SerializeField] private Popup _audioConfigPopup;

    [Header("Settings")]
    [SerializeField] private float _animationSpeed;

    private void Awake()
    {
        _openMenuButton.onClick.AddListener(OpenMenuButtonClicked);
        _closeMenuButton.onClick.AddListener(CloseMenuButtonClicked);
        _closeMenuBottonButton.onClick.AddListener(CloseMenuButtonClicked);
        _graphicsConfigButton.onClick.AddListener(() => {
            _graphicsConfigPopup.gameObject.SetActive(true);
        });
        _audioConfigButton.onClick.AddListener(() => {
            BaseCanvasController.Instance.ShowPopup(_audioConfigPopup, null);
        });
        _restoreDefaultVideoSettingsButton.onClick.AddListener(RestoreDefaultVideoSettingsButtonClicked);
    }

    private void CloseMenuButtonClicked()
    {/*
        StartCoroutine(CloseMenu());
        IEnumerator CloseMenu()
        {
            Vector3 t = _sideMenu.transform.localScale;

            while (_sideMenu.transform.localScale.x > 0)
            {
                _sideMenu.transform.localScale -= new Vector3(Time.deltaTime * _animationSpeed, 0, 0);
                yield return null;
            }

            _sideMenu.transform.localScale = new Vector3(0, t.y, t.z);
        }*/
    }

    private void OpenMenuButtonClicked()
    {/*
        StartCoroutine(OpenMenu());
        IEnumerator OpenMenu()
        {
            Vector3 t = _sideMenu.transform.localScale;

            while (_sideMenu.transform.localScale.x < 1f)
            {
                _sideMenu.transform.localScale += new Vector3(Time.deltaTime * _animationSpeed, 0, 0);
                yield return null;
            }

            _sideMenu.transform.localScale = new Vector3(1, t.y, t.z);
        }*/
    }

    private void RestoreDefaultVideoSettingsButtonClicked()
    {
        GameManager.Instance.RestoreDefaultVideoSettings();
    }
}
