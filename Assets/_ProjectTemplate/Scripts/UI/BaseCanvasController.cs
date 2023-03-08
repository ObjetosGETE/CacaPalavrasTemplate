using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseCanvasController : MonoBehaviour
{
    public static BaseCanvasController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }        
    } 

    public void ShowPopup(Popup pupUp, ContentScriptableObject content)
    {
        if (content)
        {
            pupUp.SetContent(content);

            Debug.Log("PopUp Title: " + pupUp.Content.Title);
            Debug.Log("PopUp Content: " + pupUp.Content.Content);
        }

        pupUp.Open();
    }

    public void ShowInfoPanel(InfoPanel infoPanel, string refObj, string callback = "", ContentScriptableObject content = null)
    {
        infoPanel.transform.parent.gameObject.SetActive(true);

        if (content)
        {
            infoPanel.SetContent(content);
        }
        infoPanel.gameObject.SetActive(true);
    }

    public void ShowQuestionPanel(QuestionPanel questionPanel, string refObj, QuestionScriptableObject questionContent, string callback = "")
    {
        questionPanel.transform.parent.gameObject.SetActive(true);

        questionPanel.SetContent(questionContent);

        var q = questionPanel.Content;
        string debugMessage = $"Sending question to front: Question title: '{q.QuestionStatement}' 'Correct feedback: ' '{q.CorrectAnswerFeedback}'" +
            $"' Wrong feedback: ' '{q.WrongAnswerFeedback}'";

        Debug.Log(debugMessage);

        questionPanel.gameObject.SetActive(true);        
    }   
}
