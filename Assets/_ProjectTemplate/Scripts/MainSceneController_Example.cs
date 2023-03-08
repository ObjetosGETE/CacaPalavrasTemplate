using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class MainSceneController_Example : MonoBehaviour
{
    [Header("Popups")]
    [SerializeField] private Popup _popUpPanel;
    [SerializeField] private InfoPanel _infoPanel;
    [SerializeField] private QuestionPanel _questionPanel;

    [Header("Content")]
    [SerializeField] private ContentScriptableObject _popUpContent1;
    [SerializeField] private ContentScriptableObject _popUpContent2;
    [SerializeField] private ContentScriptableObject _infoPanelContent;

    [SerializeField] private QuestionScriptableObject _questionContent;

    [Header("Buttons")]
    [SerializeField] private Button _infoPanelOkButton;

    [Header("Dialogs")]
    [SerializeField] private BlockReference _fungusDialogBlock;

    [Header("Buttons")]
    [SerializeField] private Button _buttonPopup1;
    [SerializeField] private Button _buttonPopup2;
    [SerializeField] private Button _buttonInfoPanel;
    [SerializeField] private Button _buttonQuestionPanel;
    [SerializeField] private Button _buttonDialogs;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _sfxToggle;

    private void Awake()
    {
        _infoPanelOkButton.onClick.AddListener(CloseInfoPanel);

        _musicToggle.isOn = false;
        _sfxToggle.isOn = false;

        _buttonPopup1.onClick.AddListener(() => ShowpopUp(_popUpPanel, _popUpContent1));
        _buttonPopup2.onClick.AddListener(() => ShowpopUp(_popUpPanel, _popUpContent2));

        _buttonInfoPanel.onClick.AddListener(() => {
            BaseCanvasController.Instance.ShowInfoPanel(_infoPanel, name, nameof(CloseInfoPanel), _infoPanelContent);
        });

        _buttonQuestionPanel.onClick.AddListener(() => {
            BaseCanvasController.Instance.ShowQuestionPanel(_questionPanel, name, _questionContent, nameof(CloseQuestionPanel));
        });

        _buttonDialogs.onClick.AddListener(DialogSequence);

        _musicToggle.onValueChanged.AddListener(ToggleMusic);
        _sfxToggle.onValueChanged.AddListener(ToggleSFX);
    }

    private void DialogSequence()
    {
        _fungusDialogBlock.Execute();
    }
    private void ShowpopUp(Popup pop, ContentScriptableObject content)
    {
        BaseCanvasController.Instance.ShowPopup(pop, content);
    }

    private void ToggleMusic(bool value)
    {        
        if (value)
        {
            AudioManager.Instance.Play("Music");
        }
        else
        {
            AudioManager.Instance.Stop("Music");
        }  
    }

    public void MeExecuteAoFinalDeUmBloco()
    {
        Debug.Log("Fui chamado");
    }

    private void ToggleSFX(bool value)
    {
        if (value)
        {
            AudioManager.Instance.Play("Effect");
        }
        else
        {
            AudioManager.Instance.Stop("Effect");
        }
    }

    public void CloseInfoPanel()
    {
        _infoPanel.transform.parent.gameObject.SetActive(false);
    }

    public void CloseQuestionPanel()
    {
        _questionPanel.transform.parent.gameObject.SetActive(false);
    }
}