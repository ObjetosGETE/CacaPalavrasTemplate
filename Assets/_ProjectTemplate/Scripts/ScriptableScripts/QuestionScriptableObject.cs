using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuestionScriptableObject", order = 1)]
public class QuestionScriptableObject : ScriptableObject
{
    [Header("ID")]
    public int ID;

    [TextArea(1, 15)]
    public string QuestionStatement;

    [Header("Correct Answer")]
    public string CorrectAnswer;

    [Header("Wrong Answer")]
    public string WrongAnswer_1;
    public string WrongAnswer_2;
    public string WrongAnswer_3;
    public string WrongAnswer_4;

    [Header("Feedbacks")]
    [TextArea(1, 15)]
    public string CorrectAnswerFeedback;

    [TextArea(1, 15)]
    public string WrongAnswerFeedback;
}