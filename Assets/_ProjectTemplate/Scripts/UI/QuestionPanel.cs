using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{
    [Header("Question Statement")]
    [SerializeField] private TextMeshProUGUI _questionStatement;
    [Header("Correct Answer")]
    [SerializeField] private TextMeshProUGUI _correctAnswer;
    [Header("Wrong Answers")]
    [SerializeField] private TextMeshProUGUI _wrongAnswer1;
    [SerializeField] private TextMeshProUGUI _wrongAnswer2;
    [SerializeField] private TextMeshProUGUI _wrongAnswer3;
    [SerializeField] private TextMeshProUGUI _wrongAnswer4;

    [Header("Content Object")]
    [SerializeField] private QuestionScriptableObject _myContent;

    [Header("FeedbackPopUp")]
    [SerializeField] private Button _correctAnswerButton;

    [Header("FeedbackPopUp")]
    [SerializeField] private Popup _feedbackPopup;

    private Button[] _answersButtons;

    public QuestionScriptableObject Content { get { return _myContent; } }

    private void Awake()
    {
        SetContent(_myContent);
        _answersButtons = GetComponentsInChildren<Button>();

        foreach(var button in _answersButtons)
        {
            button.onClick.AddListener(ShowNegativeFeedback);
        }
        _correctAnswerButton.onClick.RemoveAllListeners();
        _correctAnswerButton.onClick.AddListener(ShowPositiveFeedback);
    }

    private void ShowNegativeFeedback()
    {
        _feedbackPopup.SetContentText(Content.WrongAnswerFeedback);
        _feedbackPopup.Open();
    }
    private void ShowPositiveFeedback()
    {
        _feedbackPopup.SetContentText(Content.CorrectAnswerFeedback);
        _feedbackPopup.Open();
        _feedbackPopup.AppendFunction(Close);
    }

    private void Close()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void SetContent(QuestionScriptableObject content)
    {
        _myContent = content;

        _questionStatement.SetText(content.QuestionStatement);
        _correctAnswer.SetText(content.CorrectAnswer);
        _wrongAnswer1.SetText(content.WrongAnswer_1);
        _wrongAnswer2.SetText(content.WrongAnswer_2);
        _wrongAnswer3.SetText(content.WrongAnswer_3);
        _wrongAnswer4.SetText(content.WrongAnswer_4);
    }
}
