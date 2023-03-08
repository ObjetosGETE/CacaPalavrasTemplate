using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup), typeof(Animator))]
public class Popup : MonoBehaviour
{
    [Header("UI Refferences")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _contentText;

    private ContentScriptableObject _myContent;

    public ContentScriptableObject Content { get { return _myContent; } }

    private Animator _animator;
    private CanvasGroup _canvasGroup;
    private Button _myOkButton;
    private CloseModalWindow _closeModalWindow;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
        _myOkButton = GetComponentInChildren<Button>();
        _closeModalWindow = _myOkButton.GetComponent<CloseModalWindow>();
    }

    public void SetContent(ContentScriptableObject content)
    {
        _myContent = content;

        if (_titleText)
        {
            _titleText.SetText(content.Title);
        }
        else
        {
            Debug.LogWarning("This pop-up does not seen to have a title.");
        }
        if (_contentText)
        {
            _contentText.SetText(content.Content);
        }
        else
        {
            Debug.LogWarning("This pop-up does not seen to have content.");
        }
    }
    public void SetContentText(string contentText)
    {
        if (_contentText)
        {
            _contentText.SetText(contentText);
        }
        else
        {
            Debug.LogWarning("This pop-up does not seen to have content.");
        }
    }

    public void AppendFunction(UnityEngine.Events.UnityAction call)
    {
        _myOkButton.onClick.RemoveAllListeners();
        _myOkButton.onClick.AddListener(call);
        _closeModalWindow.AddCloseListener();
    }

    public void Open()
    {
        _animator.Play("FadeIn");
    }
    public void Close()
    {
        _animator.Play("FadeOut");
    }
}