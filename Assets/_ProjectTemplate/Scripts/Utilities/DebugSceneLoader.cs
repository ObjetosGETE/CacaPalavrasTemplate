using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public struct SceneButton
{
    public Button button;
    public int sceneIndex;
}

[RequireComponent(typeof(Animator))]
public class DebugSceneLoader : MonoBehaviour
{
    [SerializeField] private Button _openClosePanel;

    [SerializeField] private SceneButton[] _sceneButtons;

    private bool _panelState;

    private Animator _myAnimator;

    private void Start()
    {
        _myAnimator = GetComponent<Animator>();
        _openClosePanel.onClick.AddListener(TogglePanelState);
        SetButtons();
    }

    private void SetButtons()
    {
        foreach(var b in _sceneButtons)
        {
            b.button.onClick.AddListener(() => SceneManager.LoadScene(b.sceneIndex));
        }
    }

    private void TogglePanelState()
    {
        _panelState = !_panelState;
        _myAnimator.SetBool("ToggleIn", _panelState);
    }
}